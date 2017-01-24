using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCirclesBehavior : MonoBehaviour {

	public GameObject raceCircle;
	public Vector3 position;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "player") {
			GameObject newRaceCircle = Instantiate(raceCircle,position,Quaternion.identity) as GameObject;
			Destroy (this);
		}
	}
}
