using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int vidas;
    [SerializeField] private GameObject HUD;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        /*PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();*/
    }

    private void Start()
    {
        // Ahora SI PersistenceManager ya existe
        vidas = PersistenceManager.Instance != null
            ? PersistenceManager.Instance.GetVidas()
            : 3;

        Debug.Log("Vidas cargadas: " + vidas);
    }

    public void SubstractScore(int ataqueEnemigo)
    {
        Debug.Log("VIDAS ANTES DE RESTAR: " + vidas);

        vidas -= ataqueEnemigo;

        Debug.Log("VIDAS DESPUES DE RESTAR: " + vidas);

        PersistenceManager.Instance.SaveVidas(vidas);

        if (vidas <= 0) Derrota();
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

   public void ResetTodo()
    {
        PersistenceManager.Instance.SaveVidas(3);
        PersistenceManager.Instance.SaveLevel(false);
        vidas = 3;
        PersistenceManager.Instance.Save();
    }
}
