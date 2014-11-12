using UnityEngine;
using System.Collections;

public class Configuracao : MonoBehaviour {

	public float gravidade = 70;
	// Use this for initialization
	void Start () {
		Physics.gravity = new Vector3(0, -gravidade, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
