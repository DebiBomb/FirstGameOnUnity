using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromSides : MonoBehaviour
{
    
    public bool isDead = false;
    public Camera mainCamera;

    void Update()
    {

        if (isDead) 
        {
        this.gameObject.SetActive(false);
        Invoke("RespawnPlayer", 5f);
        isDead = false;
        }
    }

    private void RespawnPlayer() 
    {
    Vector3 cameraPos = mainCamera.transform.position;
    this.transform.position = new Vector2(cameraPos.x, cameraPos.y);
    this.gameObject.SetActive(true);
    }

    // Questa funzione viene chiamata quando il Player entra in collisione con un altro collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Controlliamo se il collider con cui il Player ha colliso è quello della Main Camera
        if (collision.collider.gameObject.name == "Main Camera")
        {
            // Se sì, impostiamo la variabile isDead su true
            isDead = true;
        }
    }

    
}
