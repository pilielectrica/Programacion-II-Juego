using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int vidas = 3;
    Mover personaje;

    private void Start()
    {
        personaje = FindObjectOfType<Mover>();
        vidas = 3;
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            vidas = Mathf.Max(PlayerPrefs.GetInt("Vidas"), 0);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SubstractScore(int ataqueEnemigo)
    {
        vidas -= ataqueEnemigo;
        PersistenceManager.Instance.SaveVidas(vidas);
        personaje.ataqueEnemigo = false;
        if (vidas <= 0) { Derrota(); }


    }


    public int GetVidas()
    {
        return vidas;
    }

    void Derrota()
    {
        ResetTodo();
        SceneManager.LoadScene("Menu");
      
    }
    void ResetTodo()
    {
        PersistenceManager.Instance.SaveVidas(3);
        PersistenceManager.Instance.Save();
    }

}