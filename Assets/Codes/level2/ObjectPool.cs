using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [Header("Prefabs de proyectiles")]
    [SerializeField] private GameObject prefabDerecha;
    [SerializeField] private GameObject prefabIzquierda;

    [SerializeField] private int poolSize = 5;

    private List<GameObject> poolDerecha;
    private List<GameObject> poolIzquierda;

    void Start()
    {
        poolDerecha = new List<GameObject>();
        poolIzquierda = new List<GameObject>();

        // Crear pool para proyectiles derecha
        for (int i = 0; i < poolSize; i++)
        {
            GameObject objR = Instantiate(prefabDerecha);
            objR.SetActive(false);
            poolDerecha.Add(objR);
        }

        // Crear pool para proyectiles izquierda
        for (int i = 0; i < poolSize; i++)
        {
            GameObject objL = Instantiate(prefabIzquierda);
            objL.SetActive(false);
            poolIzquierda.Add(objL);
        }
    }

    // 🔥 Devuelve un prefab según dirección
    public GameObject GetPooledObject(bool mirandoDerecha)
    {
        List<GameObject> pool = mirandoDerecha ? poolDerecha : poolIzquierda;

        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null; // no quedan proyectiles
    }
}
