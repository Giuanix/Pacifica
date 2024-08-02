using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisioneCaramella : MonoBehaviour
{
    //funzione che controlla che 2 oggetti non siano troppo vicini, se collidono il peperoncino viene distrutto
     private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Caramella" || col.gameObject.tag == "PowerUp")
        {
           Destroy(gameObject);
        }
    }
}
