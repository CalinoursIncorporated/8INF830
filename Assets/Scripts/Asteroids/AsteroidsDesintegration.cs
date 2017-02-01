using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsDesintegration : MonoBehaviour {

	/// <summary>
	/// The health of the asteroid.
	/// </summary>
	public float health = 100f;

	/// <summary>
	/// The asteroids particules after destruction.
	/// particuleSize : size of the particules
	/// </summary>
	public GameObject[] asteroidsParticules; 
	public float particuleSize = 0.1f;

	/// <summary>
	/// Time decrementation testing
	/// previousTime is a float to stock the previous time where the function happened
	/// timeDelay is a float to indicate how often the function is being called
	/// </summary>
	public float previousTime = 0f;
	public float timeDelay = 0.1f;

	/// <summary>
	/// decrements asteroid Health every timeDelay second, and 
	/// desintegrates it if its health goes below 0
	/// </summary>
	void Update(){
		if (Time.time > previousTime + timeDelay){
			health = health - 1;
			previousTime = Time.time;
		}
		if (health <= 0f) {
			desintegrate ();
		}
	}

	/// <summary>
	/// Tells how many minerals you collect, create particules,
	/// destroy the asteroid
	/// </summary>
	public void desintegrate(){
		AsteroidsMineral asm = this.gameObject.GetComponent <AsteroidsMineral>();
		Debug.Log ("You collected " + asm.mineralCount + " minerals");
		for (int i = 0; i < asteroidsParticules.Length; i++) {
			float size = particuleSize;
			GameObject prefab = asteroidsParticules [i];
			Vector3 position = Vector3.zero;
			Vector3 origin = transform.position;

			for (int j = 0; j < 100; j++) {
				position = Random.insideUnitSphere * (2*size);
				position += origin;
				if (!Physics.CheckSphere(position, size / 2.0f)) {
					break;
				}
			}
			GameObject go = Instantiate(prefab, position, Random.rotation);
			Destroy(go.GetComponent("AsteroidsMineral"));
			Destroy(go.GetComponent("AsteroidsDesintegration"));
			go.AddComponent <AsteroidsParticules>();
			go.transform.localScale = new Vector3(size, size, size);
		}
		Destroy (this.gameObject);
	}

}
