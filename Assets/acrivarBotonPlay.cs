using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acrivarBotonPlay : MonoBehaviour
{
    [SerializeField] private GameObject botonPlaylevel1;
    [SerializeField] private GameObject botonPlaylevel2;
    [SerializeField] private GameObject botonSalir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarBotones()
    {
        botonPlaylevel1.SetActive(true);
        botonSalir.SetActive(true);
        botonPlaylevel2.SetActive(true);
    }
}
