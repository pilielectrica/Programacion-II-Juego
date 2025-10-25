using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 5;

    [Header("Carga de proyectiles")]
    [SerializeField] private int cargaMaxima = 15; // Máximo de proyectiles
    public int cargaActual { get; private set; } = 0;

    [Header("Referencia al contador de hadas")]
    [SerializeField] private ContadorDeHadas contadorHadas;

    private List<GameObject> pooledObjects;

    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        if (cargaActual <= 0)
        {
            Debug.Log("No hay carga disponible para disparar.");

            // Restar un hada del contador solo si está asignado
            if (contadorHadas != null)
                contadorHadas.UsarHada(1);

            return null;
        }

        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                cargaActual--; // Restar carga al disparar
                return obj;
            }
        }

        Debug.Log("No hay proyectiles disponibles en el pool.");
        return null;
    }

    // Se llama al recolectar un hada
    public void RecibirHada()
    {
        cargaActual = Mathf.Min(cargaActual + 3, cargaMaxima); // 3 proyectiles por hada
        Debug.Log("Carga actual: " + cargaActual);

        // Actualizar contador si existe
        if (contadorHadas != null)
        {
            for (int i = 0; i < 3; i++)
                contadorHadas.ActualizarContador();
        }
    }
}
