using UnityEngine;

public class PausePanelManager : MonoBehaviour
{
    public static PausePanelManager Instance { get; private set; }

    private void Awake()
    {
        // Si no existe una instancia, esta es la primera → se mantiene viva
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya existía uno, destruimos el duplicado
            Destroy(gameObject);
        }
    gameObject.SetActive(false);
    }
   
}
