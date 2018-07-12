using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {
    
    [SerializeField] private Transform player;
    float smooth = 4.0f;
    float tiltAngle = 60.0f;

    void Update()
    {
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle*3/4;
        float tiltAroundY = Input.GetAxis("Horizontal") * tiltAngle/2;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        Quaternion target = (Quaternion.Euler(tiltAroundX, tiltAroundY, -tiltAroundZ) * player.localRotation);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);

        if (Input.GetKey(KeyCode.Alpha1))
        {
        }
    }
}
