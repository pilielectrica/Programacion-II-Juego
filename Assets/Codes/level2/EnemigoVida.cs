using UnityEngine;

public class EnemigoVida : MonoBehaviour
{
    [Header("Configuración de vida")]
    [SerializeField, Range(1, 10)]
    private int vidaMaxima = 2; // cantidad de impactos necesarios para "morir"

    private int vidaActual;
    private EnemyManager enemyManager; // referencia al manager

    private void Start()
    {
        // Buscar el EnemyManager en la escena
        enemyManager = FindObjectOfType<EnemyManager>();
        if (enemyManager == null)
        {
            Debug.LogWarning($"⚠️ No se encontró un EnemyManager en la escena para {gameObject.name}");
        }
    }

    private void OnEnable()
    {
        vidaActual = vidaMaxima; // reiniciar al activarse (por si se reutiliza)
    }

    // 📉 Método público que el proyectil puede llamar
    public void RecibirDaño(int cantidad)
    {
        vidaActual -= cantidad;
        Debug.Log($"{gameObject.name} recibió daño. Vida restante: {vidaActual}");

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    // 💀 Acción al morir
    private void Morir()
    {
        Debug.Log($"{gameObject.name} ha sido derrotado 💀");

        // Avisar al manager
        if (enemyManager != null)
        {
            enemyManager.EnemyKilled();
        }

        // Desactivar enemigo
        gameObject.SetActive(false);
    }
}
