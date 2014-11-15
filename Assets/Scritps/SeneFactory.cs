using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SeneFactory : MonoBehaviour {

	public GameObject[] level1;
	public GameObject[] level2;
	public int level = 1;
	private Distancimentro distancimentro;
	Queue<Ground> grounds; 

	void Awake () {
		distancimentro = GameObject.Find("Inicio").GetComponent<Distancimentro>();
		grounds = new Queue<Ground> ();
	}

	void Start () {
		addGround (0);
		addGround (50);
		addGround (100);
	}
	
	// Update is called once per frame
	void Update () {

		if ((distancimentro.distancia%50 == 0) && (canCreate(distancimentro.distancia))) {
			addGround (distancimentro.distancia + 100);
			destroyGound();
		}
	}

	private void addGround(float distancia){
		GameObject chao = Instantiate (getGroundLevel(), new Vector3 (distancia, 0, 0), 
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

	private GameObject getGroundLevel(){
		switch (this.level) {
		case 1:
			return getGroundRandomFromArray(level1);
		case 2:
			return getGroundRandomFromArray(level2);
		}
		return getGroundRandomFromArray(level1);;
	}

	private GameObject getGroundRandomFromArray(GameObject[] level){
		return level [Mathf.FloorToInt ( Random.Range (0, level.Length))];
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
