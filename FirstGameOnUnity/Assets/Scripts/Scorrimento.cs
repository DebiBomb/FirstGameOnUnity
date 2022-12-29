using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorrimento : MonoBehaviour
{
    void Start()
    {
        
    }


    [SerializeField]public float scrollSpeed = 2f;

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        scrollSpeed += 0.0002f;
    }
}
