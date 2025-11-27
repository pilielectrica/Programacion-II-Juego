using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acrivarBotonPlay : MonoBehaviour
{
    [SerializeField] private GameObject boton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void activarBotonPlay()
    {
        boton.SetActive(true);
    }
}
