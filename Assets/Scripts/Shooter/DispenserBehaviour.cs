using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispenserBehaviour : MonoBehaviour
{
    public float dispencerForce, timeToCloser;
    public GameObject closer;
    public enum direction { LEFT = -1 ,RIGHT = 1};
    public direction currDir = direction.LEFT;
    private PlayerController playerController;
    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            SetActiveClosers(false);
            collision.GetComponent<LerpMovement>().StopLerp();
            Rigidbody2D ballsBody= collision.gameObject.GetComponent<Rigidbody2D>();
            ballsBody.AddForce(new Vector2((float)currDir, 0) * dispencerForce, ForceMode2D.Impulse);
            GameObject.Find("Player").GetComponent<PlayerController>().setCanUp(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            StartCoroutine(WaitnigForCloser());
        }
    }

    /// <summary>
    /// Activa o desactiva los closers
    /// </summary>
    /// <param name="status"></param>
    private void SetActiveClosers(bool status)
    {
        closer.SetActive(status);
    }

    /// <summary>
    /// Espera a que la bola pase para cerrar los closers
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitnigForCloser()
    {
        yield return new WaitForSecondsRealtime(timeToCloser);
        SetActiveClosers(true);
        playerController.setCanUp(true);
    }
}
