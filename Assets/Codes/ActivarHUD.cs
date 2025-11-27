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
        
        if (SceneManager.GetActiveScene().name == "Level 1" || SceneManager.GetActiveScene().name == "Level 2")
        { 
            HUD.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Victory")
        {
            HUD.SetActive(false);
        }

    }
}
