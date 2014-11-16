using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public float moveSpeed = 10;
	public float jumpForce = 120;
	public bool autoControl = true;
	private Rigidbody controller;
	private float distToGround;
	private bool isDoubleJump;

	public AudioClip jump;

	// Use this for initialization
	void Awake () {
		this.controller = GetComponent<Rigidbody>();
		rigidbody.freezeRotation = true;
	}

	void Start(){
		this.distToGround = collider.bounds.extents.y;
		this.isDoubleJump = false;
	}


	void FixedUpdate() {
		float horizontal = Input.GetAxis ("Horizontal");
		if ((horizontal != 0.0) || autoControl ){
			Vector3 moveDirection = new Vector3(moveSpeed, 0, 0);
			controller.MovePosition(controller.position + moveDirection * Time.deltaTime);
		}
		if (Input.GetButtonDown("Jump")){
			if (isGround()){
				applayJump();
			} else if (!this.isDoubleJump){
				this.isDoubleJump = true;
				controller.velocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
				applayJump();
			}
		}
	}
	
	void Update(){
		if (isGround ()) {
			animation.CrossFade ("run");
			this.isDoubleJump = false;
		} else {
			animation["jump_pose"].wrapMode = WrapMode.ClampForever;
			animation.CrossFade("jump_pose");
		}
	}

	bool isGround(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.5f);
		//return Physics.Raycast(new Ray(groundCheck.position, -Vector3.up));
	}

	void applayJump(){
		audio.clip = jump;
		audio.Play ();
		controller.AddForce(Vector3.up * jumpForce * 10 * Time.deltaTime, ForceMode.VelocityChange);
	}

}
