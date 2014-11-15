using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	private Transform player;
	public float centerDistanc = 10;
	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.position.x + centerDistanc, transform.position.y, transform.position.z);
	}
}
