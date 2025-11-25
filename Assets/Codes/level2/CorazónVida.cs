using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class CorazónVida : MonoBehaviour
{
    [Header("Evento que se dispara al perder una vida")]
    [SerializeField] public UnityEvent alPerderVida;
    [SerializeField] private int corazonActual;

    Mover personaje;
    // Start is called before the first frame update
    void Start()
    {
        personaje = FindObjectOfType<Mover>();
        if (PersistenceManager.Instance.GetVidas() == corazonActual)
        {
            gameObject.SetActive(false);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (personaje.ataqueEnemigo)
        {
            personaje.ataqueEnemigo = false;
            alPerderVida?.Invoke();
            gameObject.SetActive(false);

        }

    }
}
