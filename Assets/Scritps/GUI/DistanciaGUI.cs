using UnityEngine;
using System.Collections;

public class DistanciaGUI : MonoBehaviour {
	
	private Distancimentro distancimentro;
	void Start () {
		distancimentro = GameObject.Find("Inicio").GetComponent<Distancimentro>();
	}

	void Update () {
		guiText.text = distancimentro.distancia + " m";
	}
}
