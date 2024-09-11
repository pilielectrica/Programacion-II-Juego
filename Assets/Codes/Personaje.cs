using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    [Header("Audio")]
    public AudioSource pasoAudioSource;
    public AudioClip[] pasosClips; // Array de clips de pasos
    public float tiempoEntrePasos = 0.5f; // Tiempo entre cada paso

    private float moverHorizontal;
    private float moverVertical;
    private Vector2 direccion;

    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private float temporizadorPasos;
    private bool personajeMoviendose; // Para saber si el personaje se está moviendo

    private GameObject llaveColisionada;
    public GameObject VFXLlave;

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

        // Comprobar si el personaje está en movimiento
        if (direccion.magnitude > 0.1f)
        {
            personajeMoviendose = true;
            miAnimator.SetBool("IsMoving", true);
            miAnimator.SetFloat("moveX", moverHorizontal);
            miAnimator.SetFloat("moveY", moverVertical);

            // Reproducir sonido de pasos solo si está en movimiento
            temporizadorPasos -= Time.deltaTime;
            if (temporizadorPasos <= 0)
            {
                ReproducirSonidoDePaso();
                temporizadorPasos = tiempoEntrePasos; // Reiniciar temporizador
            }
        }
        else
        {
            // Si deja de moverse, parar los pasos
            personajeMoviendose = false;
            miAnimator.SetBool("IsMoving", false);
            temporizadorPasos = tiempoEntrePasos; // Reiniciar temporizador
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
            AudioClip clipSeleccionado = pasosClips[indice];
            pasoAudioSource.PlayOneShot(clipSeleccionado);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Llave"))
        {
            Debug.Log("Colisionó con la llave");

            AudioSource llaveAudio = collision.gameObject.GetComponent<AudioSource>();

            if (llaveAudio != null)
            {
                llaveAudio.Play();
            }

            llaveColisionada = collision.gameObject;
            Invoke("DesactivarLlave", 1f);
        }
    }

    void DesactivarLlave()
    {
        if (llaveColisionada != null && llaveColisionada.CompareTag("Llave"))
        {
            llaveColisionada.SetActive(false);
            VFXLlave.SetActive(false);
        }
    }
}
