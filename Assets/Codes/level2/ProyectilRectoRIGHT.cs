using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRectoRIGHT : Proyectil
{

    protected override void Mover()
    {
     
        // Establece la direcci�n del proyectil (por ejemplo, hacia la izquierda en X)
        Vector2 direction = Vector2.right;
        // Aplica la velocidad al Rigidbody
        rb.velocity = direction * speed;
    }
}