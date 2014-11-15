using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpForce = 120;
	public bool autoControl = true;
	private Rigidbody controller;

	public AudioClip jump;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
	}


	void FixedUpdate() {
		float horizontal = Input.GetAxis ("Horizontal");
		if ((horizontal != 0.0) || autoControl ){
			Vector3 moveDirection = new Vector3(moveSpeed, 0, 0);
			controller.MovePosition(controller.position + moveDirection * Time.deltaTime);
		}
		if (Input.GetButtonDown("Jump") && !isJumping()){
			playJump();
			controller.AddForce(Vector3.up * jumpForce * 10 * Time.deltaTime, ForceMode.VelocityChange);
		}
	}


	bool isJumping(){
		return Physics.Raycast(new Ray(transform.position, -Vector3.up));
	}

	void playJump(){
		audio.clip = jump;
		audio.Play();
	}
}
