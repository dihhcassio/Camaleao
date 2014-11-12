using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpForce = 120;
	public bool autoControl = true;
	private Rigidbody controller;
	private bool isJumping;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
		isJumping = false;
	}


	void FixedUpdate() {
		float horizontal = Input.GetAxis ("Horizontal");
		if ((horizontal != 0.0) || autoControl ){
			Vector3 moveDirection = new Vector3(moveSpeed, 0, 0);
			controller.MovePosition(controller.position + moveDirection * Time.deltaTime);
		}
		if (Input.GetButtonDown("Jump") && !isJumping){
			controller.AddForce(Vector3.up * jumpForce * 10 * Time.deltaTime, ForceMode.VelocityChange);
		}
	}

	void Update(){
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.collider.tag == "Ground") {
			isJumping = false;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.collider.tag == "Ground") {
			isJumping = true;
		}
	}

	void OnCollisionStay(Collision collision) {
		if (collision.collider.tag == "Ground") {
			isJumping = false;
		}
	}
}
