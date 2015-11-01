using UnityEngine;
using System.Collections;

public class headbuttzone : MonoBehaviour {

	private AudioSource audio;
	private gamemanager gameManager;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		gameManager = GameObject.Find ("Game Manager").GetComponent<gamemanager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other) {
		if (other.attachedRigidbody) {

			other.attachedRigidbody.AddExplosionForce(50.0f, transform.position, 10.0f, 2.0f);

			if (audio.isPlaying == false){
			audio.Play(); // play 'hit' sound
			}

			if (other.transform.tag == "man") {
				other.transform.GetComponent<hitObject>().ManKilledByPlayer();
			} else if (other.transform.tag == "tree") {
				other.transform.GetComponent<hitObject>().TreeHit();
			}
		}	
	}
}
