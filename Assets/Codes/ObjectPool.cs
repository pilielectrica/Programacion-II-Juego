using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // 👈 importante para usar UnityEvent

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> pooledObjects;

    [Header("Evento al quedarse sin objetos")]
    public UnityEvent onPoolEmpty; // 👈 nuevo evento

    void Awake()
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
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // ⚠️ Si llegamos hasta acá, significa que no hay más objetos disponibles
        Debug.LogWarning("⚠️ Pool vacío: no hay más objetos disponibles.");
        onPoolEmpty?.Invoke(); // 👈 Dispara el evento
        return null;
    }
}
