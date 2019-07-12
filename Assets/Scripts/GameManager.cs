using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    private int currPoints, currLevel = 0;  //cuantos puntos tengo y el nivel en el que estoy

    public List<int> EyeBulls;
    public List<int> Choices;
    public List<float> time;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(this);
        }

        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Cambia a otra escena en función de index
    /// </summary>
    /// <param name="index"></param>
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    /// <summary>
    /// Cierra el juego
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }


    public bool AddPoints()
    {
        currPoints++;
        return currPoints >= Choices[currLevel];
    }

    public int HowManyEyesBullPerLevel()
    {
        return EyeBulls[currLevel];
    }

    public float ReturnTimeForThisLevel()
    {
        return time[currLevel];
    }

    public void Nextphase()
    {
        currLevel++;
        currPoints = 0;
    }
}
