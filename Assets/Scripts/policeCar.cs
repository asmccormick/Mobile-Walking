using UnityEngine;
using System.Collections;

public class policeCar : MonoBehaviour {

	private Vector3 waypoint;
	private Rigidbody rb;
	private Quaternion directionToWaypoint;
	private Vector3 velocity = Vector3.zero;
	private float waypointTime;

	// Use this for initialization
	void Start () {
		rb = transform.GetComponent<Rigidbody>();
		NewWaypoint();
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time - waypointTime > 3) {
			NewWaypoint();
		}

		if (transform.position.y > 10 || transform.position.y < -10) {
			transform.position = Vector3.zero;
			transform.rotation = Quaternion.identity;
			rb.velocity = Vector3.zero;
		}
	}

	void FixedUpdate () {
		rb.AddRelativeForce(Vector3.forward * 200.0f);
		Vector3 relativePos = waypoint - transform.position;
		directionToWaypoint = Quaternion.LookRotation(relativePos);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, directionToWaypoint, 1.0f);
	}

	void NewWaypoint(){
		waypoint.x = Random.Range(-20.0f, 20.0f);
		waypoint.y = 0.0f;
		waypoint.z = Random.Range(-20.0f, 20.0f);
		waypointTime = Time.time;
	}
}
