using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController controller;

    private float baseSpeed = 2.0f;
    private float rotSpeedX = 3.0f;
    private float rotSpeedY = 1.5f;

    // Use this for initialization
    void Start () {
        controller = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveVector = baseSpeed * transform.forward;
        Vector3 inputs = new Vector3(moveHorizontal, 0.0f, moveVertical);

        Vector3 yaw = inputs.x * transform.right * rotSpeedX * Time.deltaTime;
        Vector3 pitch = inputs.z * -transform.up * rotSpeedY * Time.deltaTime;
        Vector3 dir = yaw + pitch;

        float maxX = Quaternion.LookRotation(moveVector + dir).eulerAngles.x;

        if (maxX < 90 && maxX > 70 || maxX > 270 && maxX < 290)
        {
        }
        else
        {
            moveVector += dir;

            transform.rotation = Quaternion.LookRotation(moveVector);
        }
        Debug.Log("Player = " + maxX);
        controller.Move(moveVector * Time.deltaTime);
    }
}
