using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

    Vector3 aim;
    bool[] weaponList = { true, false, false, false };
    CharacterController controller;

	// Use this for initialization
	void Start () {
        health = 100.0f;
        speed = 10.0f;
        position = gameObject.GetComponent<Transform>().position;
        controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded)
        {
            direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            direction = transform.TransformDirection(direction);
            direction *= -speed;
        }
        direction.y -= 100.0f * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
	}
}
