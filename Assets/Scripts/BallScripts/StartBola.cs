using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBola : MonoBehaviour
{
    public BullEyeManager bullEyeManager;
    public bool servedBola { get; private set; }
    void Start()
    {
        GetComponent<DeadBola>().StartBola();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( !servedBola && collision.gameObject.CompareTag("Player") )
        {
            print("La bola ha sido servida");
            servedBola = true;
            bullEyeManager.SetAllCollidersEyeBull(true);
        }
    }

    public void ServingBola()
    {
        print("La bola se está sirviendo");
        servedBola = false;
    }

}
