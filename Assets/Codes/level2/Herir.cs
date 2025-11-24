using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Herir : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        /* Jugador jugador = collision.gameObject.GetComponent<Jugador>();
         jugador.ModificarVida(-puntos);
         Debug.Log(" PUNTOS DE DAÑO REALIZADOS AL JUGADOR "+ puntos);
         //Destroy(gameObject);*/
        gameObject.SetActive(false);

        if (collision.collider.CompareTag("Enemigo"))
        {
            EnemigoVida enemigo = collision.collider.GetComponent<EnemigoVida>();
            enemigo.RecibirDaño(1); // o puntos
            Debug.Log("colisiono hadita con enemigo");

            gameObject.SetActive(false);
        }



    }



}
