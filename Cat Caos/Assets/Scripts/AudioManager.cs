using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private AudioSource audioSourse;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Debug.Log("Hay mas de un Manager audio"); }
    }
    void Start()
    {
        audioSourse = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio)
    {
        audioSourse.PlayOneShot(audio);
    }
}
