using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartShooter : MonoBehaviour
{
    public Transform dispencer;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            collision.GetComponent<LerpMovement>().SetLerp(transform.position,dispencer.position);
        }
    }
}
