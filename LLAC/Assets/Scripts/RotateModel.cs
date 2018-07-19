using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {
    
    float smooth = 4.0f;
    float tiltAngle = 20.0f;

    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle/2;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = Quaternion.Euler(0, 0, -tiltAroundZ);

        // Dampen towards the target rotation
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime * smooth);
        if (Input.GetKey(KeyCode.Alpha1))
        {
        }
    }
}
