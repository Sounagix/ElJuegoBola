using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSaver : MonoBehaviour
{
    public enum DIRECTION { left = -1,right = 1};
    public DIRECTION DIR;
    public float impulse;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bola"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector2((float)(DIR),1) * impulse,ForceMode2D.Impulse);
            gameObject.SetActive(false);
        }
    }

    public void ActiveLifeSavers()
    {
        gameObject.SetActive(true);
    }

}
