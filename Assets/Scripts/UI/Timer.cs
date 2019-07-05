using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer,timeOver;
    public float timerPerLevel = 60;
    private float crono, temporalTime;
    private bool runTime = true;
    public DeadBola bola;


    private void Awake()
    {
        temporalTime = timerPerLevel;
        timeOver.enabled = false;
    }

    void Update()
    {
        if (runTime)
        {
            timerPerLevel -= Time.deltaTime;
            timer.text = "" + timerPerLevel.ToString("f0");
        }
        else
        {
            timerPerLevel = 0;
        }

        if (timerPerLevel < 0) 
        {
            timerPerLevel = 0;
            runTime = false;
            bola.GameOver();
            timeOver.enabled = true;
            StartCoroutine(WaitForTimeOver());
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

    /// <summary>
    /// Reinicia el crono
    /// </summary>
    public void StartTimer()
    {
        runTime = true;
        timerPerLevel = temporalTime;
    }

    private IEnumerator WaitForTimeOver()
    {
        yield return new WaitForSecondsRealtime(1);
        timeOver.enabled = false;
    }
}
