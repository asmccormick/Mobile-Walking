using UnityEngine;
using System.Collections;

public class gamemanager : MonoBehaviour {

	public GameObject[] treesToSpawn;
	public int qtyTrees = 10;
	public GameObject human;
	public int qtyHumans = 10;
	public GameObject cactus;
	public int qtyCacti = 10;
	private Vector3 spawnPos;
	private int randSpawn;
	public GUIStyle scoreStyle;
	public int kills;
	public float distanceTravelled;
	private float startTime;
	public bool wasted = false;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		SpawnTrees();
		SpawnHumans();
		SpawnCacti();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnTrees(){
		for (int i = 0; i < qtyTrees; i++) {
			randSpawn = Random.Range(0, treesToSpawn.Length);
			spawnPos.x = Random.Range(-100.0f, 100.0f);
			spawnPos.z = Random.Range(-100.0f, 100.0f);
			Instantiate(treesToSpawn[randSpawn], spawnPos, Quaternion.identity);
		}
	}

	void SpawnHumans(){
		for (int i = 0; i < qtyHumans; i++) {
			//randSpawn = Random.Range(0, treesToSpawn.Length);
			spawnPos.x = Random.Range(-100.0f, 100.0f);
			spawnPos.z = Random.Range(-100.0f, 100.0f);
			Instantiate(human, spawnPos, Quaternion.identity);
		}
	}

	void SpawnCacti(){
		for (int i = 0; i < qtyCacti; i++) {
			//randSpawn = Random.Range(0, treesToSpawn.Length);
			spawnPos.x = Random.Range(-100.0f, 100.0f);
			spawnPos.z = Random.Range(-100.0f, 100.0f);
			Instantiate(cactus, spawnPos, Quaternion.identity);
		}
	}


	void OnGUI(){
		if (Time.time > startTime + 168.0f) {
			GUI.Box (new Rect(Screen.width/2,0,Screen.width/2,Screen.height),
			         "distance: " + distanceTravelled.ToString("#") +
			         "\n" +
			         "kills: " + kills + 
			         "\n" +
			         "total score: " + (distanceTravelled*kills).ToString("#")
			         , scoreStyle);
			if (GUI.Button(new Rect(Screen.width*0.6f,Screen.height*0.6f,Screen.width*0.3f,Screen.height*0.3f),"AGAIN?")){
				startTime = Time.time;
				Application.LoadLevel("main scene");
			}
		} else if (wasted) {
			if (GUI.Button(new Rect(Screen.width*0.6f,Screen.height*0.6f,Screen.width*0.3f,Screen.height*0.3f),"AGAIN?")){
				startTime = Time.time;
				Application.LoadLevel("main scene");
			}
		} 
	} // end of OnGUI
}
