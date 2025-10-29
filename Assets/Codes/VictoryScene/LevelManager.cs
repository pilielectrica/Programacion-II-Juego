using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // 🔹 Cargar el nivel 1
    public void CargarLevel1()
    {
        SceneManager.LoadScene("Level 1");
        
    }

    // 🔹 Cargar el nivel 2
    public void CargarLevel2()
    {
        SceneManager.LoadScene("Level 2");
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
}
