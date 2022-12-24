using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorrimento : MonoBehaviour
{
    void Start()
    {
        
    }


    [SerializeField]public float scrollSpeed = 5f;

    void Update()
    {
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
    }
}
