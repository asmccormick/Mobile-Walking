using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	private inputScript inputScript;
	private Renderer wastedSign;
	private gamemanager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.Find ("Game Manager").GetComponent<gamemanager>();
		inputScript = GameObject.Find("Player/CardboardMain").GetComponent<inputScript>();
		wastedSign = GameObject.Find("Player/CardboardMain/Head/wasted").GetComponent<Renderer>();
		wastedSign.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if (collision.transform.name == "Police Car") {
			transform.parent = collision.transform;
			inputScript.playerCanMove = false;
			wastedSign.enabled = true;
			GetComponent<Collider>().enabled = false;
			gameManager.wasted = true;
		}
	}
}
