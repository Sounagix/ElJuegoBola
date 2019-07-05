using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEyeManager : MonoBehaviour
{
    public int randomBolas;
    public GameObject eyeBull;
    private float ancho, alto;
    public GameObject[] EyeBullActivate;
    private MeshRenderer mr;
    private Vector2 posInicio;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
        posInicio = new Vector2(mr.bounds.min.x , mr.bounds.max.y);
        ancho = Vector2.Distance(posInicio, mr.bounds.max);
        alto = Vector2.Distance(posInicio, mr.bounds.min);
        posInicio.x += 0.5f;
        posInicio.y -= 0.5f;

        for(int i = 0;i<alto;i++)
        {
            for (int j = 0; j < ancho; j++)
            {
                Instantiate(eyeBull,posInicio,Quaternion.identity,transform);
                posInicio.x += 1;
            }
            posInicio.x -= ancho;
            posInicio.y -= 1;

        }
        RandomActivate();

    }
    void Start()
    {
        ChoiceTarget();
    }


    /// <summary>
    /// Activa aleatoriamente entre todos los los eyebull y los activa.
    /// </summary>
    private void RandomActivate()
    {
        EyeBullActivate = new GameObject[randomBolas];
        for(int i = 0;i < randomBolas;i++)
        {
            int index = Random.Range(0, transform.childCount);
            bool exist = transform.GetChild(index).gameObject.activeInHierarchy;
            while (exist)
            {
                index = Random.Range(0, transform.childCount);
                exist = transform.GetChild(index).gameObject.activeInHierarchy;
            }
            GameObject  Go = transform.GetChild(index).gameObject;
            EyeBullActivate[i] = Go;
            EyeBullActivate[i].SetActive(true);
        }
    }
    /// <summary>
    /// Elige un target de entre los "avariables" y selecciona uno como target.
    /// </summary>
    public void ChoiceTarget()
    {
        int rnd = Random.Range(0, EyeBullActivate.Length);
        EyeBullActivate[rnd].GetComponent<BallEye>().SetAvailable();
        EyeBullActivate[rnd].GetComponent<BallEye>().SetGreen();

    }

    /// <summary>
    /// Descactiva todos las dianas que estan activas
    /// </summary>
    public void DesactiveAllEyeBull()
    {
        for (int i = 0; i<EyeBullActivate.Length;i++)
        {
            EyeBullActivate[i].SetActive(false);
        }
    }

    /// <summary>
    /// Desactiva los colliders de los eyebulls
    /// </summary>
    /// <param name="status"></param>
    public void SetAllCollidersEyeBull(bool status)
    {
        for (int i = 0; i < EyeBullActivate.Length; i++)
        {
            EyeBullActivate[i].GetComponent<CircleCollider2D>().enabled = status;
        }
    }

    public void NewTargets()
    {
        DesactiveAllEyeBull();
        RandomActivate();
        ChoiceTarget();
    }
}
