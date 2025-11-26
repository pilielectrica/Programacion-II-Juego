using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReactivarCorazones : MonoBehaviour
{
   [SerializeField] GameObject corazon1;
    [SerializeField]GameObject corazon2;
    CorazónVida corazon;
    // Start is called before the first frame update
    void Start()
    {
        corazon = FindObjectOfType<CorazónVida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
               if (PersistenceManager.Instance.GetVidas() == 3)
        {
            corazon1.SetActive(true);
            corazon2.SetActive(true);
            
        }
        else if (PersistenceManager.Instance.GetVidas() == 2)
        {
            corazon2.SetActive(true);

        }

        }
        
    }
}
