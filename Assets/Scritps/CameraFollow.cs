using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public Transform target;
	public float centerDistanc = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (target.position.x + centerDistanc, transform.position.y, transform.position.z);
	}
}
