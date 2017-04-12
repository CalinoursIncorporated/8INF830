﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAudio : MonoBehaviour
{
    private static BaseAudio instance = null;

    public static BaseAudio Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            if (instance.GetComponent<AudioSource>().clip != GetComponent<AudioSource>().clip)
            {
                instance.GetComponent<AudioSource>().clip = GetComponent<AudioSource>().clip;
                instance.GetComponent<AudioSource>().volume = GetComponent<AudioSource>().volume;
                instance.GetComponent<AudioSource>().Play();
            }

            Destroy(this.gameObject);
            return;
        }
        instance = this;
        GetComponent<AudioSource>().Play();
        DontDestroyOnLoad(this.gameObject);
    }
}