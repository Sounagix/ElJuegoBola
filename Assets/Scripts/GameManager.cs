using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;

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

}
