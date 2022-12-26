using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuadagnoSoldi : MonoBehaviour
{
    // è dentro all'area di guadagno?
    public bool isIn = false;
    // Tasso di guadagno in denaro al secondo
    public float tassoDiGuadagno = 10.0f;

    // Totale di denaro guadagnato
    public float soldiTotali = 0.0f;

void Start()
{
    // Imposta il totale di denaro guadagnato a zero all'inizio del gioco
    soldiTotali = 0.0f;
}

void Update()
{
    // Se il personaggio si trova all'interno della zona di guadagno...
    if (isIn)
    {
        // ...aggiungi il tasso di guadagno al totale di denaro guadagnato ogni secondo
        soldiTotali += tassoDiGuadagno * Time.deltaTime;
    }

    Debug.Log(soldiTotali);
}

void onCollisionEnter(Collision collision)
{

Debug.Log("Object collided with " + collision.gameObject.name);

if (collision.gameObject.name == "AreaDiGuadagno"){
    isIn = true;
}

}

}