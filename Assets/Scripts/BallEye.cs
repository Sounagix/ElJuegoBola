using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEye : MonoBehaviour
{
    private bool available;//Determina si la diana es un target 
    public bool active { get; private set; }//Determina si está visible
    private SpriteRenderer sp;
    private void Start()
    {
        sp = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bola"))
        {
            //desaparrecer la bola
            if(available)
            {
                sp.color = Color.white;
                available = false;
                GetComponentInParent<BullEyeManager>().ChoiceTarget();
            }
            else
            {
                sp.color = Color.red;
                other.GetComponent<DeadBola>().RespawnBola();
            }
        }
    }
    public void SetActive(bool status)
    {
        active = status;
    }
    public void SetAvailable()
    {
        available = true;
        print(gameObject.name);
        sp.color = Color.green;
    }
}
