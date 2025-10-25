using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : Proyectil
{

    protected override void Mover()
    {
        // Establece la dirección del proyectil (por ejemplo, hacia la izquierda en X)
        Vector2 direction = Vector2.left;
        // Aplica la velocidad al Rigidbody
        rb.velocity = direction * speed;
    }
}