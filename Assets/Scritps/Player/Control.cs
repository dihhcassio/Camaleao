using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpForce = 120;
	public bool autoControl = true;
	private Rigidbody controller;
	float distToGround;

	public AudioClip jump;

	// Use this for initialization
	void Awake () {
		controller = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
	}

	void Start(){
		distToGround = collider.bounds.extents.y;
	}


	void FixedUpdate() {
		float horizontal = Input.GetAxis ("Horizontal");
		if ((horizontal != 0.0) || autoControl ){
			Vector3 moveDirection = new Vector3(moveSpeed, 0, 0);
			controller.MovePosition(controller.position + moveDirection * Time.deltaTime);
		}
		if (Input.GetButtonDown("Jump") && isGround()){
			playJump();
			controller.AddForce(Vector3.up * jumpForce * 10 * Time.deltaTime, ForceMode.VelocityChange);
		}
	}


	bool isGround(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
		//return Physics.Raycast(new Ray(groundCheck.position, -Vector3.up));
	}

	void playJump(){
		audio.clip = jump;
		audio.Play();
	}
}
