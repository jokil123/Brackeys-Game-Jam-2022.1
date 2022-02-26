using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public new Rigidbody rigidbody;
    public Transform cameraTransform;
    public Transform desiredCammeraRotationTransform;

    private Plane floorPlane = new Plane(Vector3.up, Vector3.zero);
    private float distanceToStopMoving = 1.0f;
    public float moveSpeed = 0.03f;
    private float rotateSpeed = 7.0f;
    private Quaternion desiredCameraRotation;
    private float cameraRotationCoolDown = 0.2f;
    private float cameraRotationCoolDownStart = 0f;


    // Start is called before the first frame update
    void Start()
    {
        desiredCammeraRotationTransform.rotation = cameraTransform.rotation;
        desiredCameraRotation = cameraTransform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (Time.time > cameraRotationCoolDownStart + cameraRotationCoolDown)
            {
                desiredCammeraRotationTransform.Rotate(0, -90, 0, Space.World);
                desiredCameraRotation = desiredCammeraRotationTransform.rotation;
                cameraRotationCoolDownStart = Time.time;
            }
            //desiredCameraRotation *= Quaternion.Euler(0, 90, 0);
            //desiredCameraRotation.Rotate(0, 90, 0, Space.World);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
        RotateCamera();
        if (Input.GetMouseButton(0))
        {
            Move();
        } else
        {
            SetAnimatorMoveSpeed(0);
        }

    }

    private void Move()
    {
        Vector3 location = GetMouseLocation();
        // location.y += 2;

        //rigidbody.AddRelativeForce((location - transform.position).normalized * moveSpeed, ForceMode.Force);
        rigidbody.position = Vector3.MoveTowards(rigidbody.position, location, moveSpeed);

        SetAnimatorMoveSpeed(35);
    }

    private void SetAnimatorMoveSpeed(float speed)
    {
        foreach (Animator animator in rigidbody.gameObject.GetComponentsInChildren<Animator>())
        {
            if (animator.gameObject.name.Contains("Character Animated")) {
                animator.SetFloat("Walking Speed", moveSpeed * speed);
            }
        }
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
        cameraTransform.rotation = Quaternion.RotateTowards(cameraTransform.rotation, desiredCameraRotation, 10);
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