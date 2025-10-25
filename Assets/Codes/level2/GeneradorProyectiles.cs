using System.Collections.Generic;
using UnityEngine;

public class GeneradorProyectiles : MonoBehaviour
{
    [SerializeField] private float fuerzaDisparo = 10f; // velocidad del proyectil
    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    // Ahora recibe la posición desde la que disparar
    public void Disparar(Vector2 direccion, Vector3 posicion)
    {
        GameObject proyectil = objectPool.GetPooledObject();
        if (proyectil == null) return;

        // Poner en la posición que recibe
        proyectil.transform.position = posicion;
        proyectil.SetActive(true); // <-- solo ahora se hace visible

        // Ajustar flip según dirección
        SpriteRenderer rend = proyectil.GetComponent<SpriteRenderer>();
        if (rend != null)
            rend.flipX = direccion.x < 0;

        // Aplicar velocidad
        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = direccion.normalized * fuerzaDisparo;
    }
}
