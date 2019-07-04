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
    public void ChoiceTarget()
    {
        EyeBullActivate[Random.Range(0, EyeBullActivate.Length)].GetComponent<BallEye>().SetAvailable();
    }

}
