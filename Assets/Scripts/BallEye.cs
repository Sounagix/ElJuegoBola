using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEye : MonoBehaviour
{
    private bool available;//Determina si la diana es un target 
    private SpriteRenderer sp;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {

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


    /// <summary>
    /// Pone como avariable (target) a un eyebull
    /// </summary>
    public void SetAvailable()
    {
        available = true;
    }

    public void SetGreen()
    {
        sp.color = Color.green;
    }

}
