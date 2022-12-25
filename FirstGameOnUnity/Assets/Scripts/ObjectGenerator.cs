using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    // intervallo di tempo tra la generazione di ogni oggetto
    public float timeInterval = 1;  // in secondi

    // distanza minima tra oggetti generati
    public float minDistance = 10;

    // prefab dell'oggetto da generare
    public GameObject objectPrefab;

    // lista di oggetti generati
    private List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        // avvia il loop di generazione degli oggetti
        StartCoroutine(GenerateObjects());
    }

    IEnumerator GenerateObjects()
    {
        while (true)  // esegui il loop all'infinito
        {
            // calcola le dimensioni del range di spazio in base alla posizione della main camera
            Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
            Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

            float minX = bottomLeft.x;
            float maxX = topRight.x;
            float minY = bottomLeft.y;
            float maxY = topRight.y;

            // genera una nuova posizione casuale per l'oggetto
            float x = Random.Range(minX, maxX);
            float y = Random.Range(minY-12, maxY-8);

            // verifica che la posizione x sia maggiore o minore di almeno 3 rispetto all'ultimo oggetto generato
            bool validPosition = true;
            if (objects.Count > 0)
            {
                float lastX = objects[objects.Count - 1].transform.position.x;
                if (Mathf.Abs(x - lastX) < 3)
                {
                    validPosition = false;
                }
            }

            // verifica se la posizione è troppo vicina ad un oggetto già generato
            bool tooClose = false;
            foreach (GameObject obj in objects)
            {
                float distance = Vector2.Distance(obj.transform.position, new Vector2(x, y));
                if (distance < minDistance)
                {
                    tooClose = true;
                    break;
                }
            }

            // se la posizione è valida, crea l'oggetto e aggiungilo alla lista
            if (validPosition && !tooClose)
            {
                GameObject obj = Instantiate(objectPrefab, new Vector2(x, y), Quaternion.identity);
                objects.Add(obj);
            }

        // attendi l'intervallo di tempo prima di generare un nuovo oggetto
        yield return new WaitForSeconds(timeInterval);
        }
    }
}