using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private Transform player;
    public float deltaPosition=5;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector2 playerPosition = player.position;
        transform.position = new Vector2(transform.position.x, playerPosition.y - deltaPosition);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            DeadManager.instancia.PlayerLose();
        }
    }

}
