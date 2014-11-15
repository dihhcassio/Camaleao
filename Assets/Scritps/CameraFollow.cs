using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {



	public float centerDistancX = 18;
	
	private Transform player;
	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}

	void Start(){
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x + centerDistancX, 
		                                  transform.position.y , transform.position.z);
	}
}
