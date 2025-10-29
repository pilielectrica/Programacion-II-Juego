using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [Header("Panel de Pausa")]
    [SerializeField] private GameObject panelPausa;

    private bool juegoPausado = false;

    void Update()
    {
        // Detectar tecla ESC para pausar o reanudar
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausarJuego();
        }
    }

    // 🔹 Alterna entre pausa y reanudación
    public void PausarJuego()
    {
        juegoPausado = !juegoPausado;

        if (juegoPausado)
        {
            Time.timeScale = 0f; // Detiene el tiempo
            if (panelPausa != null)
                panelPausa.SetActive(true);
            Debug.Log("Juego pausado");
        }
        else
        {
            Time.timeScale = 1f; // Reanuda el tiempo
            if (panelPausa != null)
                panelPausa.SetActive(false);
            Debug.Log("Juego reanudado");
        }
    }

    // 🔹 Si querés forzar pausa desde otro script o evento
    public void ForzarPausa(bool pausar)
    {
        juegoPausado = pausar;
        Time.timeScale = pausar ? 0f : 1f;

        if (panelPausa != null)
            panelPausa.SetActive(pausar);

        Debug.Log(pausar ? "Pausado manualmente" : "Reanudado manualmente");
    }
}
