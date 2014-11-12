using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeneFactory : MonoBehaviour {

	public GameObject ground;
	private float tempoAtual;
	private Distancimentro distancimentro;
	Queue<Ground> grounds; 
	void Start () {
		distancimentro = GameObject.Find("Inicio").GetComponent<Distancimentro>();
		grounds = new Queue<Ground> ();
		addGround (0);
		addGround (500);
		addGround (1000);
		addGround (1500);
	}
	
	// Update is called once per frame
	void Update () {

		if ((distancimentro.distancia%500 == 0) && (canCreate(distancimentro.distancia))) {
			addGround (distancimentro.distancia + 1500);
			destroyGound();
		}
	}

	private void addGround(float distancia){
		GameObject chao = Instantiate (ground, new Vector3 (distancia, 0, 0), 
		                               transform.rotation) as GameObject;
		chao.tag = "Ground";
		Ground g = new Ground(distancimentro.distancia, chao) ;
		grounds.Enqueue(g);
	}

	private bool canCreate(int distacia){
		foreach(Ground g in grounds)
		{
			if (g.getDistance() == distacia){
				return false;
			}
		} 
		return true;

	}

	private void destroyGound(){
		if (grounds.Count > 4) {
			Ground g = grounds.Dequeue();
			Destroy(g.getGround());
		}
	}

	class Ground {
		private GameObject groud;
		private int distance;

		public Ground (int i, GameObject g){
			this.groud = g;
			this.distance = i;
		}

		public int getDistance(){
			return this.distance;
		}

		public GameObject getGround(){
			return this.groud; 
		}
	}
}
