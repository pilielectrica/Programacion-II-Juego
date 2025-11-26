using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ActivarHUD : MonoBehaviour
{
   [SerializeField] private GameObject HUD;
    // Start is called before the first frame update
    void Start()
    {
        

            
    }

    // Update is called once per frame
    void Update()
    {
        string escenactual = "Level 1";
        if (SceneManager.GetActiveScene().name == escenactual)
        { 
            HUD.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Menu")
        {
            HUD.SetActive(false);
        }

    }
}
