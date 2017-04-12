using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity {

	public AudioClip explosionSound;

	private AudioSource audioSource;

	void Awake(){
		audioSource = GetComponent<AudioSource>();
	}

    protected override void Start()
    {
        base.Start();
        name = "Red Raven";
    }

    protected override void Update()
    {
        base.Update();
        

    }

    protected override void endOfLife()
    {
		audioSource.PlayOneShot (explosionSound);
        base.endOfLife();
    }

}
