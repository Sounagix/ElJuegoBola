using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPhones : MonoBehaviour
{
    private AudioSource headphones;
    public AudioClip[] playList;
    // Start is called before the first frame update
    void Start()
    {
        headphones = GetComponent<AudioSource>();
    }


    public void PlayThatAudio(AudioClip clip)
    {
        headphones.clip = clip;
        headphones.Play();
    }

    public void playWinPhase()
    {
        headphones.clip = playList[0];
        headphones.Play();
    }
}
