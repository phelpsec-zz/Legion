﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private GameObject player;

    private Vector3 offsetFromPlayer;

    void Awake() {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start () {
        
        offsetFromPlayer = transform.position - player.transform.position;
	}
	
	void LateUpdate () {

        transform.position = player.transform.position + offsetFromPlayer;
    }
}
