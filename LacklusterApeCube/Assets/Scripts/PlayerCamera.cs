﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {


    public Transform lookAt;

    private Vector3 desiredPosition;
    private float offset = 0.5f;
    private float distance = 5.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        desiredPosition = lookAt.position + (-transform.forward * distance) + (transform.up * offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.2f);

            transform.LookAt(lookAt.position + (Vector3.up * offset));
	}
}
