using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backing : MonoBehaviour
{
    public GameObject bola;
    public float backingSpeed;
    private float timeToBack;
    private Vector2 posOrigen, posGoal;
    private bool backing;

    void Start()
    {
        posOrigen = transform.position;
    }


    void Update()
    {

        if (backing)
        {
            timeToBack += backingSpeed * Time.deltaTime;
        }

        //Cuando llega la barra a su destino
        if (backing && transform.position.y <= 1)
        {
            backing = false;
            timeToBack = 0;
            GetComponent<PlayerController>().BackingPlayer(false);
            bola.GetComponent<DeadBola>().StartBola();
        }

    }

    private void FixedUpdate()
    {
        if (backing)
            transform.position = Vector2.Lerp(posGoal, posOrigen, timeToBack);

    }

    public void ActiveBacking()
    {
        backing = true;
        posGoal = transform.position;
    }
}
