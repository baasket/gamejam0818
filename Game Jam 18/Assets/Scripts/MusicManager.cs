using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;
    //public AudioClip theme_002;
    //public AudioClip theme_003;

    private AudioSource audioSource;
    private int currentlyPlaying;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        currentlyPlaying = 0;
        audioSource.clip = music[0];
        audioSource.Play();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!audioSource.isPlaying)
        {
            int oldMusic = currentlyPlaying;

            while(currentlyPlaying == oldMusic)
            {
                currentlyPlaying = Random.Range(0, music.Length);
                if(music.Length < 2)
                {
                    break;
                }
            }
            
            audioSource.clip = music[currentlyPlaying];
            audioSource.Play();
        }
	}




}
