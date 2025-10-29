using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    [Header("Audio")]
    public AudioSource pasoAudioSource;
    public AudioClip[] pasosClips;
    public float tiempoEntrePasos = 0.5f;

    private float moverHorizontal;
    private float moverVertical;
    private Vector2 direccion;

    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private float temporizadorPasos;
    private bool personajeMoviendose;

    private GameObject llaveColisionada;
    public GameObject VFXLlave;
    private bool tieneLlave = false;

    [Header("Puerta")]
    public GameObject puerta;
    public Vector3 posicionVictoria;

    [Header("Posiciones")]
    public Vector3 posicionInicial;
    public int experienceValue;

    [Header("Bazooka")]
    public Transform puntoBazooka; // Lugar donde se coloca el bazooka (ajustable en el inspector)
    private GameObject bazooka; // Referencia al bazooka recogido
    private SpriteRenderer bazookaRenderer; // Para cambiar sorting y flip

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        temporizadorPasos = tiempoEntrePasos;
    }

   private void Update()
{
    moverHorizontal = Input.GetAxis("Horizontal");
    moverVertical = Input.GetAxis("Vertical");
    direccion = new Vector2(moverHorizontal, moverVertical);

    // 🔹 Avisar al bazooka de la dirección horizontal
    if (bazooka != null)
    {
        Bazooka bazookaScript = bazooka.GetComponent<Bazooka>();

        if (moverHorizontal > 0)
            bazookaScript.CambiarDireccion(true); // mira a la derecha
        else if (moverHorizontal < 0)
            bazookaScript.CambiarDireccion(false); // mira a la izquierda
    }

    if (direccion.magnitude > 0.1f)
    {
        personajeMoviendose = true;
        miAnimator.SetBool("IsMoving", true);
        miAnimator.SetFloat("moveX", moverHorizontal);
        miAnimator.SetFloat("moveY", moverVertical);

        temporizadorPasos -= Time.deltaTime;
        if (temporizadorPasos <= 0)
        {
            ReproducirSonidoDePaso();
            temporizadorPasos = tiempoEntrePasos;
        }

        ActualizarBazookaOrientacion(); // Esto mantiene la orientación según arriba/abajo
    }
    else
    {
        personajeMoviendose = false;
        miAnimator.SetBool("IsMoving", false);
        temporizadorPasos = tiempoEntrePasos;
    }
}


    private void FixedUpdate()
    {
        if (personajeMoviendose)
        {
            miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
        }
    }

    void ReproducirSonidoDePaso()
    {
        if (pasosClips.Length > 0 && personajeMoviendose)
        {
            int indice = Random.Range(0, pasosClips.Length);
            pasoAudioSource.PlayOneShot(pasosClips[indice]);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("agua"))
    {
        Debug.Log("Caíste al agua 🌊 (trigger). Volviendo al inicio...");
        miRigidbody2D.transform.position = posicionInicial;
    }
}


    void OnCollisionEnter2D(Collision2D collision)
    {
        // 🔑 Llave
        if (collision.gameObject.CompareTag("Llave"))
        {
            Debug.Log("Colisionó con la llave");
            AudioSource llaveAudio = collision.gameObject.GetComponent<AudioSource>();
            if (llaveAudio != null) llaveAudio.Play();

            llaveColisionada = collision.gameObject;
            Invoke("DesactivarLlave", 1f);
            tieneLlave = true;
        }

        // 🚪 Puerta
        if (collision.gameObject.CompareTag("Door"))
        {
            if (tieneLlave)
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                PlayerProgression playerProgression = player.GetComponent<PlayerProgression>();
                playerProgression.GainExperience(experienceValue);

                Debug.Log("¡Ganaste! Has abierto la puerta.");
                miRigidbody2D.transform.position = posicionVictoria;
            }
            else
            {
                Debug.Log("Necesitas la llave para abrir la puerta.");
            }
        }

        // 💀 Enemigo
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            Debug.Log("¡Perdiste! Colisionaste con el enemigo.");
            miRigidbody2D.transform.position = posicionInicial;
        }
        if (collision.gameObject.CompareTag("agua"))
{
    Debug.Log("Caíste al agua 🌊, volviendo al inicio.");
    miRigidbody2D.transform.position = posicionInicial;
}

        // 💥 Bazooka
        if (collision.gameObject.CompareTag("Bazooka"))
        {
            Debug.Log("Has recogido el bazooka");

            bazooka = collision.gameObject;
            bazookaRenderer = bazooka.GetComponent<SpriteRenderer>();

            // Desactivar colisión y física
            Collider2D col = bazooka.GetComponent<Collider2D>();
            if (col != null) col.enabled = false;
            Rigidbody2D rb = bazooka.GetComponent<Rigidbody2D>();
            if (rb != null) rb.simulated = false;

            // Convertirlo en hijo del jugador
            bazooka.transform.SetParent(transform);

            // Posicionarlo en el punto de agarre
            if (puntoBazooka != null)
            {
                bazooka.transform.localPosition = puntoBazooka.localPosition;
                bazooka.transform.localRotation = puntoBazooka.localRotation;
            }

            Debug.Log("Bazooka ahora es hijo del jugador.");
        }
    }

    void DesactivarLlave()
    {
        if (llaveColisionada != null && llaveColisionada.CompareTag("Llave"))
        {
            llaveColisionada.SetActive(false);
            if (VFXLlave != null)
                VFXLlave.SetActive(false);
        }
    }

    void ActualizarBazookaOrientacion()
    {
        if (bazooka == null || bazookaRenderer == null)
            return;

        // Horizontal predominante
        if (Mathf.Abs(moverHorizontal) > Mathf.Abs(moverVertical))
        {
            // ➡️ Derecha
            if (moverHorizontal > 0)
            {
                bazookaRenderer.sortingOrder = 3000;
                bazookaRenderer.flipX = true;
            }
            // ⬅️ Izquierda
            else
            {
                bazookaRenderer.sortingOrder = 3000;
                bazookaRenderer.flipX = false;
            }
        }
        else
        {
            // ⬆️ Arriba → detrás del jugador
            if (moverVertical > 0)
            {
                bazookaRenderer.sortingOrder = -2000;
            }
            // ⬇️ Abajo → delante del jugador
            else
            {
                bazookaRenderer.sortingOrder = 3000;
            }
        }
    }
}
