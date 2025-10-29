using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjetivoPasarEscenaVictoria : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            PasarASiguienteEscena();
        }
    }

    // Si el trigger es un collider con "Is Trigger" activado, usa este en vez del otro
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Objetivo"))
        {
            PasarASiguienteEscena();
        }
    }

    private void PasarASiguienteEscena()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual + 1);
    }
}
