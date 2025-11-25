using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyHud : MonoBehaviour
{
    public static DontDestroyHud Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            // Evita que ejecute Start o corutinas
            gameObject.SetActive(false);
            Destroy(gameObject);
            return;
        }
    }

}
