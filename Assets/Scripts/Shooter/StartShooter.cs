using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShooter : MonoBehaviour
{
    public AudioClip chargingAudio;
    public Transform rampTrigger;
    public CloserManager closer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            closer.desactiva(true);
            Vector2 shootTill = new Vector2(rampTrigger.position.x, rampTrigger.position.y);
            collision.GetComponent<LerpMovement>().SetLerp(transform.position,shootTill);
            Camera.main.GetComponent<HeadPhones>().PlayThatAudio(chargingAudio);
        }
    } 
}
