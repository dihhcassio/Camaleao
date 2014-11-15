using UnityEngine;
using System.Collections;

public class Distancimentro : MonoBehaviour {

	public int distancia = 0;
	private Transform player;

	// Use this for initialization
	void Awake () {
		player = GameObject.Find ("Player").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		distancia = Mathf.FloorToInt(player.transform.position.x - transform.position.x);
	}
}
