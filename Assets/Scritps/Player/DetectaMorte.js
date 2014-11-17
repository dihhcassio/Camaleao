#pragma strict
var RagPlayer	: GameObject;
var AuxPayer	: GameObject;
var Inicio	: Transform;
var Fim		: Transform;
var Tempo	: float;
var AlturaInicial : float;
function Start () {
	AlturaInicial = transform.position.y;
}

function Update () {
	if (Tempo<1){
		Tempo+=Time.deltaTime;
	}
	if(Physics.Linecast(Inicio.position,Fim.position) || 
		(rigidbody.velocity.x>=10 && Tempo>1) ||
		(transform.position.y<AlturaInicial-10)){
		AuxPayer = Instantiate(RagPlayer, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}