using UnityEngine;
using System.Collections;

public class inputScript : MonoBehaviour {

	float accelerometerUpdateInterval = 1.0f / 60.0f;  // originally 1.0
	// The greater the value of LowPassKernelWidthInSeconds, the slower the filtered value will converge towards current input sample (and vice versa).
	float lowPassKernelWidthInSeconds = 0.1f;  // originally 1.0
	// This next parameter is initialized to 2.0 per Apple's recommendation, or at least according to Brady! ;)
	float shakeDetectionThreshold = 0.5f;  // originally 1.0
	
	private float lowPassFilterFactor;
	private Vector3 lowPassValue = Vector3.zero;
	private Vector3 acceleration;
	private Vector3 deltaAcceleration;

	public GameObject headbuttZone;
	public GameObject player;
	public Transform targetLocation;
	private Vector3 velocity = Vector3.zero;
	private AudioSource stepSound;
	private AudioSource whooshSound;
	//private float distanceTravelled;  // moved this function over to gameManager
	public GUIStyle bigFont;
	public bool playerCanMove = true;
	private gamemanager gameManager;


	// Use this for initialization
	void Start () {
		lowPassFilterFactor = accelerometerUpdateInterval / lowPassKernelWidthInSeconds;
		shakeDetectionThreshold *= shakeDetectionThreshold;
		//Debug.Log("skakeThresh = " + shakeDetectionThreshold);
		lowPassValue = Input.acceleration;
		headbuttZone = GameObject.Find("Player/headbutt zone");
		player = GameObject.Find("Player");
		headbuttZone.SetActive(false);
		stepSound = GameObject.Find("Player/step sound").GetComponent<AudioSource>();
		whooshSound = GameObject.Find("Player/whoosh sound").GetComponent<AudioSource>();
		gameManager = GameObject.Find ("Game Manager").GetComponent<gamemanager>();

	}
	
	// Update is called once per frame
	void Update () {
 		acceleration = Input.acceleration;
		lowPassValue = Vector3.Lerp(lowPassValue, acceleration, lowPassFilterFactor);
		deltaAcceleration = acceleration - lowPassValue;
		if (deltaAcceleration.sqrMagnitude >= shakeDetectionThreshold)
		{
			// Perform your "shaking actions" here, with suitable guards in the if check above, if necessary to not, to not fire again if they're already being performed.
		}


		/*
		 * could not get the x-axis to produce good results.  Turning the phone created too much noise.
		 * 
		if (deltaAcceleration.x >= shakeDetectionThreshold) {
			targetLocation.Translate (Vector3.right * (deltaAcceleration.x - 1));
			Debug.Log ("accel = " + (deltaAcceleration.x - 1));
		*/

		if (deltaAcceleration.z >= shakeDetectionThreshold * 2) {
			StartCoroutine(Headbutt());
		} else if (deltaAcceleration.y >= shakeDetectionThreshold) {
			targetLocation.Translate(Vector3.forward * Mathf.Abs(deltaAcceleration.y) * 0.75f);
			gameManager.distanceTravelled += Vector3.Distance(player.transform.position, targetLocation.position);
			if (stepSound.isPlaying == false) {
				stepSound.Play();
			}
		}

		if (playerCanMove == true) {
			player.transform.position = Vector3.SmoothDamp(player.transform.position, targetLocation.position, ref velocity, 1.0f);
		}

	} //  end of Update()

	IEnumerator Headbutt(){
		headbuttZone.SetActive(true);
		if (whooshSound.isPlaying == false) {
			whooshSound.Play();
		}
		yield return new WaitForSeconds(0.25f);
		headbuttZone.SetActive(false);
	}
}
