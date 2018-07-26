using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFire : MonoBehaviour {

    private float baseSpeed = 15.0f;
    private float rotSpeedX = 2.0f;
    private float rotSpeedY = 2.0f;
    float yaw;
    float pitch;
    Quaternion startRot;
    Quaternion finishRot;

    public GameObject ball;
    Rigidbody ballRB;
    public Transform shotPos;
    public float firePower;
    public int power = 100;

    // Use this for initialization
    void Start () {
        firePower *= power;
	}

    void FixedUpdate()
    {
        float moveYaw = Input.GetAxis("Horizontal");
        float movePitch = Input.GetAxis("Vertical");

        yaw += moveYaw * rotSpeedX;
        pitch += movePitch * rotSpeedY;
        startRot = transform.rotation;
        finishRot = Quaternion.Euler(pitch + 60.0f, yaw, 0);
        transform.rotation = Quaternion.Lerp(startRot, finishRot, Time.deltaTime * baseSpeed);

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject ballCopy = Instantiate(ball, shotPos.position, transform.rotation) as GameObject;
        ballRB = ballCopy.GetComponent<Rigidbody>();
        ballRB.AddForce(transform.forward * firePower);
    }
}
