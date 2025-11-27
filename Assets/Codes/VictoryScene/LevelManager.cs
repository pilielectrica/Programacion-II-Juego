using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    // 🔹 Cargar el nivel 1

    private void Start()
    {
       
    }
    public void CargarLevel1()
    {
        
            SceneManager.LoadScene("Level 1");
            
        
        
    }

    // 🔹 Cargar el nivel 2
    public void CargarLevel2()
    {

        if (PersistenceManager.Instance.getLevel2() == true)
        {
            SceneManager.LoadScene("Level 2");
        }
        
       
    }

    // 🔹 Volver al menú principal
    public void CargarMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // 🔹 Salir del juego (opcional)
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
    public void ReloadEscena()
    {
        
       
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        PersistenceManager.Instance.SaveVidas(3);
        PersistenceManager.Instance.Save();
    }
}
