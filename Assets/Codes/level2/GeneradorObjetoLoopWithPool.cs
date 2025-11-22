using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoopWithPool : MonoBehaviour
{

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    private ObjectPool objectPool;
    [SerializeField] private Mover player;

    private bool disparando = false;

    [SerializeField] private Bazooka bazooka; // arrastrás tu bazooka en el inspector


    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    void Update()
    {
        if (player.BazookaTaken && Input.GetKeyDown(KeyCode.Space))
        {
            if (!disparando)
            {
                // 🔹 Empezar disparo
                InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
                disparando = true;
                Debug.Log("▶ Disparo iniciado");
            }
            else
            {
                // 🔹 Detener disparo
                CancelInvoke(nameof(GenerarObjetoLoop));
                disparando = false;
                Debug.Log("⏹ Disparo detenido");
            }
        }
    }


    void GenerarObjetoLoop()
    {
        GameObject pooledObject = objectPool.GetPooledObject(bazooka._mirandoDerecha);

        if (pooledObject != null)
        {
            pooledObject.transform.position = transform.position;
            pooledObject.transform.rotation = Quaternion.identity;
            pooledObject.SetActive(true);
        }
    }

}