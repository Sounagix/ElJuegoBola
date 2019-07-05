using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MAX = 20, MIN = 0;
    public float upSpeed, angleSpeed, maxRotation, minRotarion;
    public Vector2 startPosition { get; private set; }//posición inicial del jugador al empezar el juego
    private float xSpeed, ySpeed,diference;
    private Rigidbody2D rb;
    public bool Backing { get; private set; }//Variable que determina si el jugador vuelve a la posición de origen
    private bool posMovement;
    private bool canUp = true;
    private void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        diference = Mathf.Floor(Vector2.SignedAngle(Vector2.right, transform.right));
        ySpeed = Input.GetAxis("Vertical");
        xSpeed = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!Backing && xSpeed > 0 && diference < maxRotation)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, xSpeed) * angleSpeed);
        }
        else if (!Backing && xSpeed < 0 && diference > minRotarion)
        {
            transform.Rotate(new Vector3(0.0f, 0.0f, xSpeed) * angleSpeed);
        }

        if (!Backing && Mathf.Floor(transform.position.y) > MIN && ySpeed < 0)
        {
            transform.Translate(Vector2.up * upSpeed * ySpeed, Space.World);
        }
        else if (!Backing && canUp && Mathf.Floor(transform.position.y) < MAX && ySpeed > 0) 
        {
            transform.Translate(Vector2.up * upSpeed * ySpeed, Space.World);
        }
    }

    /// <summary>
    /// When player lost the ball
    /// </summary>
    public void BackingPlayer(bool status)
    {
        Backing = status;
    }
    public void setCanUp(bool can)
    {
        canUp = can;
    }

}
