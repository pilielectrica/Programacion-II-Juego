using UnityEngine;
public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemigos;
    [SerializeField] private BalsaMovimientoLoop[] balsas;

    private int enemigosMuertos = 0;

    public void EnemyKilled()
    {
        enemigosMuertos++;
        if (enemigosMuertos >= enemigos.Length)
        {
            foreach (var b in balsas)
                b.ActivarMovimiento(); // Activamos el script
        }
    }
}
