using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public GameObject virtualCamera;

    private Plane floorPlane = new Plane(Vector3.up, Vector3.zero);
    private float distanceToStopMoving = 1.0f;
    private float moveSpeed = 0.02f;
    private float rotateSpeed = 10.0f;
    private float cameraStartingAngle = -45f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        virtualCamera.transform.rotation.eulerAngles = new Vector3(45, cameraStartingAngle, 0);
    }

    // Update is called once per frame
    void Update()
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
