﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ControladorEstadisticas : MonoBehaviour
{
    public float restarAgua;
    public float restarComida;
    public float restarComidaEstamina;
    public float restarEstamina;


    

    [Range(0,100)]
    public float agua = 100;
    [Range(0, 100)]
    public float comida = 30;
    [Range(0, 100)]
    public float estamina = 100;
    private float vida = 100;

    private bool restaurandoEstamina = false;

    public Slider[] sliders;


    public void Update()
    {
        for(int i = 0;i < sliders.Length; i++)
            sliders[i].maxValue = 100;

        sliders[0].value = agua;
        sliders[1].value = comida;
        sliders[2].value = estamina;

        if (agua >= 0)
            agua -= restarAgua * Time.deltaTime;

        if (comida >= 0 && !restaurandoEstamina)
        {
            Debug.Log("Resta normal");
            comida -= restarComida * Time.deltaTime;
        }
        else if(comida >= 0 && restaurandoEstamina)
        {
            Debug.Log("Resta incrementada");
            comida -= restarComidaEstamina * Time.deltaTime;
        }


        if (gameObject.GetComponent<FirstPersonController>().isRunning && estamina >= 0 && !gameObject.GetComponent<FirstPersonController>().isIdle)
                estamina -= restarEstamina * Time.deltaTime;
            else if (gameObject.GetComponent<FirstPersonController>().isIdle)
            {
                if (estamina >= 100)
                {
                    restaurandoEstamina = false;
                    return;
                }
                else
                {
                    estamina += restarEstamina * Time.deltaTime / 1.5f;
                    restaurandoEstamina = true;
                }
            }
            else if (gameObject.GetComponent<FirstPersonController>().m_IsWalking)
            {
                if (estamina >= 100)
                {
                    restaurandoEstamina = false;
                    return;
                }
                else
                {
                    estamina += restarEstamina * Time.deltaTime / 3;
                    restaurandoEstamina = true;
                }

            }
            else
            {
                estamina = 0;
            }
        
        
        


    }
}
