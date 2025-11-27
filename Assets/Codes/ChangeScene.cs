using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Cambia a la siguiente escena en el orden del Build Settings
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
    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}
