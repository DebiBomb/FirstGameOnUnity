using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject objectPrefab;
    public float generationRate = 1.0f;
    public float xRange = 10.0f;
    public Camera mainCamera;

    void Update()
    {
        // Genera un nuovo oggetto ogni generationRate secondi
        if (Time.timeSinceLevelLoad % generationRate < Time.deltaTime)
        {
            // Scegli una posizione casuale all'interno del range di generazione
            float xPos = Random.Range(-xRange, xRange);
            float yPos = Random.Range(-12, -8);

            // Ottieni la posizione corrente della main camera
            Vector3 cameraPos = mainCamera.transform.position;

            // Crea una nuova istanza dell'oggetto prefab alla posizione scelta
            Instantiate(objectPrefab, new Vector2(cameraPos.x + xPos, cameraPos.y + yPos), Quaternion.identity);
        }
    }
}
