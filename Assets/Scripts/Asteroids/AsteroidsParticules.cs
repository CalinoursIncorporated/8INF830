using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsParticules : MonoBehaviour {

	/// <summary>
	/// Destroy the particule after 3 seconds
	/// </summary>
	void Start () {
		Invoke ("destroy", 3f);
	}

	void Update () {
	}
		
	public void destroy(){
		Destroy (this.gameObject);
	}
}
