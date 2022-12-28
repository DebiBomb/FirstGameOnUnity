using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallReflect : MonoBehaviour
{
    // Il nome del collider della telecamera
    public string colliderName = "Box Collider 2D";

    // Viene chiamato una volta al frame
    void Update()
    {
        // Controlla se la palla sta collidendo con il collider della telecamera
        if (Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), LayerMask.GetMask(colliderName)))
        {
            // Inverti la direzione orizzontale della palla
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
    }
}