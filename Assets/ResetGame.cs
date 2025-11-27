using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public bool Victory = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.ResetTodo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void volverAlMenu()
    {
        Victory = true;
        SceneManager.LoadScene("Menu");
    }
    public void Salir()
    {
        Application.Quit();
    }
       
}
