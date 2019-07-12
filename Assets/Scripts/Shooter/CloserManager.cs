using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloserManager : MonoBehaviour
{
    public void desactiva(bool  value)
    {
        GetComponent<Collider2D>().enabled = !value;
        GetComponent<MeshRenderer>().enabled = !value;
    }
}
