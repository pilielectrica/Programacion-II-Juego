using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateSistemaParticulasBoton : MonoBehaviour
{// hice este codigo para que el brillito se active en el boton
    // del level 1 si no pasamos el level 2
    // y lo mismo para el level 2 si ya estamos en ese nivel. entonces
    // el brillo aparece donde tenemos que apretar para seguir jugando, como un 
    // detalle que nos guìa.
    ParticleSystem particulasLevel;
    // Start is called before the first frame update
    [SerializeField] private bool estado;
    private void Awake()
    {
        particulasLevel = GetComponentInChildren<ParticleSystem>();
    }
    void Start()
    {
        if (PersistenceManager.Instance.getLevel2() == estado)
        {

            particulasLevel.gameObject.SetActive(true);
        }
        else
        {
            particulasLevel.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
