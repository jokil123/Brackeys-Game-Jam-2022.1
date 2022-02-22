using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public Transform cameraTransform;

    private Plane floorPlane = new Plane(Vector3.up, Vector3.zero);
    private float distanceToStopMoving = 1.0f;
    private float moveSpeed = 0.2f;
    private float rotateSpeed = 7.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCamera();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
        if (Input.GetMouseButton(0))
        {
            Move();
        }

    }

    private void Move()
    {
        Vector3 location = GetMouseLocation();
        location.y += 2;

        //rigidbody.AddRelativeForce((location - transform.position).normalized * moveSpeed, ForceMode.Force);
        rigidbody.position = Vector3.MoveTowards(rigidbody.position, location, moveSpeed);
    }

    private void Rotate()
    {
        Quaternion _lookRotation;
        Vector3 _direction;
        Vector3 _target = GetMouseLocation();
        
        _target.y = transform.position.y;

        _direction = (_target - transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * rotateSpeed);
    }

    private void RotateCamera()
    {
        cameraTransform.Rotate(0, 90, 0, Space.World);
    }

    private Vector3 GetMouseLocation()
    {
        Ray rayCast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (floorPlane.Raycast(rayCast, out float distance))
        {
            return rayCast.GetPoint(distance);
        }
        return Vector3.zero;
    }
}
