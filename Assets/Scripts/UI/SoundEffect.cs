using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    private AudioSource headPhones;
    private bool Bypass, bucle;
    private AudioClip bucleClip;

    void Start()
    {
        headPhones = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (bucle && Bypass)
        {
            headPhones.PlayOneShot(bucleClip);
            StartCoroutine(WaitBypass());
        }
    }

    private IEnumerator WaitBypass()
    {
        Bypass = false;
        yield return new WaitForSecondsRealtime(1);
        Bypass = true;
    }


    public void PlayThatAudioInBucle(AudioClip clip)
    {
        bucleClip = clip;
        Bypass = true;
        bucle = true;
    }

    public void StopBlucle()
    {
        Bypass = false;
        bucle = false;
    }

    public void PlayThatAudio(AudioClip clip)
    {
        headPhones.clip = clip;
        headPhones.Play();
    }
}
