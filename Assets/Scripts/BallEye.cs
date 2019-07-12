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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bola"))
        {
            //desaparrecer la bola
            if(available)
            {
                available = false;
                sp.color = Color.white;
                if (GameManager.instancia.AddPoints())//true si ganas
                {
                    GameManager.instancia.Nextphase();
                    Camera.main.GetComponent<HeadPhones>().playWinPhase();
                    // hacer todo lo necesario para subir al siguiente nivel
                }
                else//Para el siguiente target
                {
                    GetComponentInParent<BullEyeManager>().ChoiceTarget();

                }

            }
            else
            {
                sp.color = Color.red;
                DeadManager.instancia.PlayerLose();
                StartCoroutine(WaitForWrongTouch());
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

    private IEnumerator WaitForWrongTouch()
    {
        yield return new WaitForSecondsRealtime(1);
        sp.color = Color.white;
    }

}
