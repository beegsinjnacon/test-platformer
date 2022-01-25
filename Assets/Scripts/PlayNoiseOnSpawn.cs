using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayNoiseOnSpawn : MonoBehaviour
{
    public AudioSource audioSource;
    public float volume = 0.5f;

	private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
