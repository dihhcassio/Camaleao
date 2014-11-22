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

	tamanhox = Screen.width/4;
	tamanhoy = Screen.height/4;
	
	posx = Screen.width/2 - tamanhox/2;
	posy = Screen.height/3 - tamanhoy/3;

	if (GUI.Button(Rect(posx, posy, tamanhox, tamanhoy), "Recomeçar")){
		Application.LoadLevel('CoqueiroScene');
	}
	if(GUI.Button(Rect(posx, posy+posy,tamanhox, tamanhoy), "Sair")){
		Application.LoadLevel('TelaInicial');
	}
}