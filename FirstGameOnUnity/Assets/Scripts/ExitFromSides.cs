using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromSides : MonoBehaviour
{
    
    public bool isDead = false;
    public Camera mainCamera;
    public string colliderName = "Edge Collider 2D";

    void Update()
    {

        if (isDead) 
        {
        this.gameObject.SetActive(false);
        Invoke("RespawnPlayer", 5f);
        isDead = false;
        }

        // Se il Player viene a contatto con il colliderName, in questo caso: Edge Collider 2D
        if (Physics2D.IsTouchingLayers(GetComponent<Collider2D>(), LayerMask.GetMask(colliderName)))
            isDead = true;

    }

    private void RespawnPlayer() 
    {
    Vector3 cameraPos = mainCamera.transform.position;
    this.transform.position = new Vector2(cameraPos.x, cameraPos.y);
    this.gameObject.SetActive(true);
    }


    
}
