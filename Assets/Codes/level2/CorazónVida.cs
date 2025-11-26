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
    int vidas;
    Mover personaje;
    // Start is called before the first frame update
    void Start()
    {
        personaje = FindObjectOfType<Mover>();
       
       
    }

    public void esconderCorazon(int _vidas)
    {
        if (_vidas == corazonActual)
        {
           gameObject.SetActive(false);
        }
       
    }
    private void Update()
    { vidas = PersistenceManager.Instance.GetVidas();
        esconderCorazon(vidas);
        
    }
}
