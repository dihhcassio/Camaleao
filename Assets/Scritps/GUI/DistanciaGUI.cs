using UnityEngine;
using System.Collections;

public class DistanciaGUI : MonoBehaviour {
	
	private Distancimentro distancimentro;
	private int Record;
	void Start () {
		distancimentro = GameObject.Find("Inicio").GetComponent<Distancimentro>();
		Record = PlayerPrefs.GetInt("Record");
	}

	void Update () {
		guiText.text = "Distancia Percorrida: " + distancimentro.distancia + " m";
		guiText.text += "\nRecord: " + Record + " m";
		if (Record < distancimentro.distancia) {
			PlayerPrefs.SetInt("Record",distancimentro.distancia);
		}
	}
}
