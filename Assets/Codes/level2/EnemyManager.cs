using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigos;

    [Header("Scripts que se activarán al matar a todos los enemigos")]
    [SerializeField] private MonoBehaviour[] scriptsAActivar;

    private int enemigosMuertos = 0;

    public void EnemyKilled()
    {
        enemigosMuertos++;
        Debug.Log($"🩸 Enemigo eliminado ({enemigosMuertos}/{enemigos.Length})");

        // Si ya matamos a todos
        if (enemigosMuertos >= enemigos.Length)
        {
            foreach (var script in scriptsAActivar)
            {
                if (script != null)
                {
                    script.enabled = true;  // 🔥 Activa el script
                    Debug.Log($"✅ Script activado: {script.GetType().Name}");
                }
            }
        }
    }
   
}

