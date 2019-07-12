using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMovement : MonoBehaviour
{
    private Vector2 oriPos, goalPos;
    public float lerpSpeed;
    private float lerpTime;
    public bool makeLerp;


    void Update()
    {
        if (makeLerp)
        {
            lerpTime += lerpSpeed * Time.deltaTime;
            transform.position = Vector2.Lerp(oriPos,goalPos,lerpTime);
        }
        else
        {
            lerpTime = 0;
        }
    }

    public void SetLerp(Vector2 posOrigen,Vector2 posGoal)
    {
        makeLerp = true;
        oriPos = posOrigen;
        goalPos = posGoal;
    }

    public void StopLerp()
    {
        makeLerp = false;
    }

}
