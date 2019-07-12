using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timer,timeOver;
    private float crono, temporalTime, timerPerLevel;
    private bool runTime = true, finalLap;
    public DeadManager deadManager;
    public AudioClip backCount, timeUp;
    private SoundEffect soundEffect;


    private void Awake()
    {
        timerPerLevel = GameManager.instancia.ReturnTimeForThisLevel();
        temporalTime = timerPerLevel;
        timeOver.enabled = false;
        soundEffect = GetComponentInParent<SoundEffect>();
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
            deadManager.PlayerLose();
            timeOver.enabled = true;
            soundEffect.StopBlucle();
            soundEffect.PlayThatAudio(timeUp);
            StartCoroutine(WaitForTimeOver());
        }

        if (!finalLap && timerPerLevel <= 10)
        {
            finalLap = true;
            soundEffect.PlayThatAudioInBucle(backCount);
            timer.color = Color.red;
            timer.fontSize = 30;
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
        finalLap = false;
        soundEffect.StopBlucle();
        timerPerLevel = temporalTime;
    }

    /// <summary>
    /// Espera un segundo para devolver al estado original.
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitForTimeOver()
    {
        yield return new WaitForSecondsRealtime(1);
        timeOver.enabled = false;
        timer.fontSize = 20;
        timer.color = Color.yellow;
    }
}
