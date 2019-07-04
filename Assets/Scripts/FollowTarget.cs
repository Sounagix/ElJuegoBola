using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform objToFollow;
    public float diferenceInY;//La diferencia para que el objeto no quede centrado
    public float distanceInZ;//La distancia para que la cámara se quede a la distancia

    private void FixedUpdate()
    {
        transform.position = new Vector3(objToFollow.position.x, objToFollow.position.y + diferenceInY,distanceInZ);
    }
}
