using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;

    private float baseSpeed = 5.0f;
    private float rotSpeedX = 4.0f;
    private float rotSpeedY = 4.0f;
    private float gravity = 7.0f;
    private float cameraDist = 8.0f;
    private float cameraOffset = 4.0f;
    Vector3 moveVector;
    Vector3 lookVector;
    Vector3 vertVector;
    private float fallVelocity = 0;

    [SerializeField] private bool isBall;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        moveVector = baseSpeed * transform.forward;
        lookVector = moveVector;
    }
    // Update is called once per frame
    void FixedUpdate() {

        float moveYaw = Input.GetAxis("Horizontal");
        float movePitch = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            moveVector += baseSpeed * transform.forward;
        }
        if (isBall)
        {
            gravity = 10.0f;
        }
        else
        {
            //Vector3 moveVector = baseSpeed * transform.forward;
            Vector3 inputs = new Vector3(moveYaw, 0.0f, movePitch);

            Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
            Vector3 pitch = inputs.z * -transform.up * rotSpeedY * Time.deltaTime;
            Vector3 dir = yaw + pitch;

            float maxX = Quaternion.LookRotation(lookVector + dir).eulerAngles.x;



            if (maxX < 90 && maxX > 70 || maxX > 270 && maxX < 290)
            {
                
            }
            else
            {
                moveVector += dir;
                lookVector += dir;
                transform.rotation = Quaternion.LookRotation(lookVector);
            }

            //grav
            moveVector += Vector3.down * gravity * Time.deltaTime;

            //flymove
            vertVector = (moveVector - Vector3.ProjectOnPlane(Vector3.up, moveVector));
            fallVelocity = vertVector.magnitude;
            moveVector -= vertVector * Time.deltaTime * 1.02f;
            moveVector += vertVector.magnitude * transform.forward * Time.deltaTime;
            Debug.Log("vert: " + vertVector);

            //camera
            Vector3 moveCam = transform.position - (transform.forward * cameraDist) + (transform.up * cameraOffset);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, moveCam, 0.04f);
            Camera.main.transform.LookAt(transform.position + (moveVector + lookVector));
            Debug.Log("move: " + moveVector);



            controller.Move(moveVector * Time.deltaTime);



        }
        
    }
}
