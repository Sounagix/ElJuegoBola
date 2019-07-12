using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    private Transform player;
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        Vector2 playerPosition = player.position;
        transform.position = new Vector2(transform.position.x, playerPosition.y);
    }
}
