using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBola : MonoBehaviour
{
    public Transform spawnPoint;
    private GameObject player;

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

    public void StartBola()
    {
        transform.position = spawnPoint.position;
    }

}
