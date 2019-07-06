using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBola : MonoBehaviour
{
    public BullEyeManager bullEyeManager;
    public bool servedBola { get; private set; }
    void Start()
    {
        DeadManager.instancia.ServeBolaOnStart();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( !servedBola && collision.gameObject.CompareTag("Player") )
        {
            servedBola = true;
            bullEyeManager.SetAllCollidersEyeBull(true);
        }
    }

    public void ServingBola()
    {
        servedBola = false;
    }

}
