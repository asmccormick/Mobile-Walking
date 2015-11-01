using UnityEngine;
using System.Collections;

public class hitObject : MonoBehaviour {

	public bool canDie = true;
	private AudioSource myAudio;
	private ParticleSystem myParticles;
	private gamemanager gameManager;

	// Use this for initialization
	void Start () {
		myAudio = GetComponent<AudioSource>();
		myParticles = transform.Find("Particle System").GetComponent<ParticleSystem>();
		gameManager = GameObject.Find ("Game Manager").GetComponent<gamemanager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ManKilledByPlayer(){
		if (canDie) {
			canDie = false;
			myAudio.Play();
			myParticles.Play();
			gameManager.kills += 1;
		}
	}

	public void ManKilledByPolice(){
		if (canDie) {
			canDie = false;
			myAudio.Play();
			myParticles.Play();
		}
	}

	public void TreeHit(){
		myAudio.Play();
		myParticles.Play();
	}


	void OnCollisionEnter (Collision collision) {
		if (transform.tag == "man" && collision.transform.name == "Police Car") {
			ManKilledByPolice();
		}
		if (transform.tag == "tree" && collision.transform.name == "Police Car") {
			TreeHit();
		}
	}
}
