using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    private float moverHorizontal;
    private float moverVertical;
    private Vector2 direccion;

    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    public AudioSource llaveAudio;

    private GameObject llaveColisionada;
    public GameObject VFXLlave;

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        moverVertical = Input.GetAxis("Vertical");
        direccion = new Vector2(moverHorizontal, moverVertical);

        // Actualizar los parámetros del Animator
        if (direccion.magnitude > 0.1f)
        {
            miAnimator.SetBool("IsMoving", true);
            miAnimator.SetFloat("moveX", moverHorizontal);
            miAnimator.SetFloat("moveY", moverVertical);
        }
        else
        {
            miAnimator.SetBool("IsMoving", false);
        }
    }

    private void FixedUpdate()
    {
        miRigidbody2D.MovePosition(miRigidbody2D.position + direccion * (velocidad * Time.fixedDeltaTime));
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
