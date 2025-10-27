using UnityEngine;

public class GeneradorProyectiles : MonoBehaviour
{
    [SerializeField] private float fuerzaDisparo = 10f;
    [SerializeField] private Transform puntoDisparo;
    [SerializeField] private Vector2 direccion = Vector2.right;
    private ObjectPool objectPool;

    void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar(direccion, puntoDisparo.position);
        }
    }

    public void Disparar(Vector2 dir, Vector3 posicion)
    {
        GameObject proyectil = objectPool.GetPooledObject();
        if (proyectil == null) return;

        proyectil.transform.position = posicion;

        Rigidbody2D rb = proyectil.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.velocity = dir.normalized * fuerzaDisparo;

        SpriteRenderer sr = proyectil.GetComponent<SpriteRenderer>();
        if (sr != null)
            sr.enabled = true; // asegurar que se vea
    }
}
