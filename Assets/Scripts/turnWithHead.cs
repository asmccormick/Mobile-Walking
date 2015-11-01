using UnityEngine;
using System.Collections;

public class turnWithHead : MonoBehaviour {

	public Transform head;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float yRot = head.transform.rotation.eulerAngles.y;
		transform.rotation = Quaternion.Euler (0,yRot,0);
	}
}
