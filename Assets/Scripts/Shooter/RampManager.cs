using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RampManager : MonoBehaviour
{
    public void setEnabled(bool value)
    {
        GetComponent<MeshRenderer>().enabled = value;
        GetComponent<BoxCollider2D>().isTrigger = !value;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<StartBola>().desactivaRampas();
    }
}
