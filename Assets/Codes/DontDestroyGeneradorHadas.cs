using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGeneradorHadas: MonoBehaviour
{
    public static DontDestroyGeneradorHadas Instance { get; private set; }

    private void Awake()
    {
        // Si no existe una instancia, esta es la primera → se mantiene viva
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existía uno, destruimos el duplicado
            Destroy(gameObject);
        }
        gameObject.SetActive(false);
    }

}
