using UnityEngine;
using System.Collections;

public class Distancimentro : MonoBehaviour {

	public int distancia = 0;
	public Transform player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		distancia = Mathf.FloorToInt(player.transform.position.x - transform.position.x);
	}
}
