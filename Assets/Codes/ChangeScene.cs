using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Cambia a la siguiente escena en el orden del Build Settings
    public void IrASiguienteEscena()
    {
        // Obtiene el índice de la escena actual
        int indiceActual = SceneManager.GetActiveScene().buildIndex;

        // Calcula el índice de la siguiente
        int siguienteIndice = indiceActual + 1;

        // Si no hay más escenas, vuelve a la primera (opcional)
        if (siguienteIndice >= SceneManager.sceneCountInBuildSettings)
        {
            siguienteIndice = 0;
        }

        // Carga la siguiente escena
        SceneManager.LoadScene(siguienteIndice);
    }
}
