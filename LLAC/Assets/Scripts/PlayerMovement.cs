using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;

    private float baseSpeed = 5.0f;
    private float rotSpeedX = 4.0f;
    private float rotSpeedY = 4.0f;
    private float gravity = 2.0f;
    private float cameraDist = 8.0f;
    private float cameraOffset = 3.0f;
    Vector3 moveVector;

    [SerializeField] private bool isBall;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
        //moveVector = baseSpeed * transform.forward;
    }
    // Update is called once per frame
    void FixedUpdate() {

        float moveYaw = Input.GetAxis("Horizontal");
        float movePitch = Input.GetAxis("Vertical");

        if (isBall)
        {
            gravity = 10.0f;
        }
        else
        {
            gravity = 2.0f;

            //Vector3 moveVector = baseSpeed * transform.forward;
            Vector3 inputs = new Vector3(moveYaw, 0.0f, movePitch);

            Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
            Vector3 pitch = inputs.z * -transform.up * rotSpeedY * Time.deltaTime;
            Vector3 dir = yaw + pitch;

            float maxX = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;


            if (maxX < 90 && maxX > 70 || maxX > 270 && maxX < 290)
            {
                moveVector += Vector3.down * gravity * Time.deltaTime;
            }
            else
            {
                //Vector3 vertVel = 
                moveVector += dir;
                moveVector -= Vector3.Magnitude(moveVector) * transform.forward;


                transform.rotation = Quaternion.LookRotation(moveVector);

            }
            

            //camera
            Vector3 moveCam = transform.position - (transform.forward * cameraDist) + (transform.up * cameraOffset);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, moveCam, 0.04f);
            Camera.main.transform.LookAt(transform.position + (moveVector * 10));
            Debug.Log(Vector3.Magnitude(moveVector));

            if (Input.GetKeyDown(KeyCode.Space))
            {
                controller.Move(moveVector * 5 * Time.deltaTime);
            }
            else
            {
                controller.Move(moveVector * Time.deltaTime);
            }
            



        }
        
    }
}
