using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadManager : MonoBehaviour
{
    public static DeadManager instancia;
    public GameObject bola;
    public GameObject player;
    public GameObject canvas;
    public GameObject eyeBallManager;
    public Transform[] spawnPoints;
    public GameObject[] lifeSavers;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayerLose()
    {
        player.GetComponent<PlayerController>().BackingPlayer(true);
        player.GetComponent<Backing>().ActiveBacking();
        ServeBolaOnStart();
    }

    public void ServeBolaOnStart()
    {
        eyeBallManager.GetComponent<BullEyeManager>().SetAllCollidersEyeBull(false);
        bola.GetComponent<StartBola>().ServingBola();
        canvas.GetComponentInChildren<Timer>().StartTimer();
        bola.transform.position = spawnPoints[(int)(Random.Range(0, spawnPoints.Length))].position;
        player.GetComponent<PlayerController>().setCanUp(false);
        
        foreach(GameObject lf in lifeSavers)
        {
            lf.SetActive(true);
        }
    }
}
