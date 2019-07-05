using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer;
    public float timerPerLevel = 60;
    private float crono, temporalTime;
    private bool runTime = true;


    private void Awake()
    {
        temporalTime = timerPerLevel;
    }

    void Update()
    {
        if (runTime)
        {
            timerPerLevel -= Time.deltaTime;
            timer.text = "" + timerPerLevel.ToString("f0");
        }
    }

    /// <summary>
    /// Para la cuenta atras
    /// </summary>
    public void StopTime()
    {
        runTime = false;
        crono = timerPerLevel;
    }

    /// <summary>
    /// retorna los segundo que sobraron
    /// </summary>
    /// <returns></returns>
    private float ReturmExtraTime()
    {
        return Mathf.Floor(temporalTime - timerPerLevel);
    }



}
