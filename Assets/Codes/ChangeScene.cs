using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    // Cambia a la siguiente escena en el orden del Build Settings
    public void IrASiguienteEscena()
    {
        if (PersistenceManager.Instance.getLevel2() == false)
        {

            int indiceActual = SceneManager.GetActiveScene().buildIndex;

            // Calcula el índice de la siguiente
            int siguienteIndice = indiceActual + 1;

            // Si no hay más escenas, vuelve a la primera (opcional)
            if (siguienteIndice >= SceneManager.sceneCountInBuildSettings)
            {
                siguienteIndice = 0;
            }
            PersistenceManager.Instance.SaveLevel(true);
            // Carga la siguiente escena
            SceneManager.LoadScene(siguienteIndice);
            
        }
        // Obtiene el índice de la escena actual
        
    }
}
