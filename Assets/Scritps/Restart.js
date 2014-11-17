#pragma strict

var tamanhox : float;
var tamanhoy : float;

var posx : float;
var posy : float;

function Start () {

}

function Update () {

}

function OnGUI () {

	tamanhox = Screen.width/5;
	tamanhoy = Screen.height/5;
	
	posx = Screen.width/2 - tamanhox/2;
	posy = Screen.height/2 - tamanhoy/2;

	if (GUI.Button(Rect(posx, posy, tamanhox, tamanhoy), "Recomeçar")){
		Application.LoadLevel('CoqueiroScene');
	}
}