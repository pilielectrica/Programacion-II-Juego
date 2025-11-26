using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    CorazónVida corazon;
    private int vidas = 3;
    Mover personaje;
    [SerializeField] private GameObject HUD;

    private void Start()
    {
        personaje = FindObjectOfType<Mover>();
        corazon = FindObjectOfType<CorazónVida>();
        vidas = 3;
        PersistenceManager.Instance.SaveVidas(3);
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            vidas = PersistenceManager.Instance.GetVidas();
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
        //personaje.ataqueEnemigo = false;
        if (vidas <= 0) { Derrota(); }


    }


    public int GetVidas()
    {
        return vidas;
    }

    void Derrota()
    {
        ResetTodo();
        HUD.SetActive(false);
        SceneManager.LoadScene("Menu");
        Debug.Log("derroooooooootaaaaaaaaaaa");
      
    }
    void ResetTodo()
    {
        PersistenceManager.Instance.SaveVidas(3);
        vidas = PersistenceManager.Instance.GetVidas();
        PersistenceManager.Instance.Save();
    }

    
}