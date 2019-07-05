using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBola : MonoBehaviour
{
    private GameObject player;
    public Transform[] spawnPoints;
    public Timer timer;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    
    public void RespawnBola()
    {
        player.GetComponent<PlayerController>().BackingPlayer(true);
        player.GetComponent<Backing>().ActiveBacking();
        GetComponent<Rigidbody2D>().Sleep();
    }

    /// <summary>
    /// Eligue un spawn point aleatorio
    /// </summary>
    public void StartBola()
    {
        timer.StartTimer();
        BullEyeManager go = GameObject.Find("BullEyeManager").GetComponent<BullEyeManager>();
        go.SetAllCollidersEyeBull(false);
        GetComponent<StartBola>().ServingBola();
        transform.position = spawnPoints[(int)(Random.Range(0, spawnPoints.Length))].position;
    }

    public void GameOver()
    {
        RespawnBola();
        StartBola();
    }

}
