using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public RampManager rampManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            collision.GetComponent<LerpMovement>().StopLerp();
            rampManager.setEnabled(true);
            GameObject.Find("Player").GetComponent<PlayerController>().setCanUp(true);
        }
    }
}
