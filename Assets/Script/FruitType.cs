using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitType : MonoBehaviour
{
    public Tipo Frutta;

    public Inventory Manager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Cassa")
        {
            if(col.gameObject.GetComponent<FruitChest>().Chest==Frutta)
            {
                Manager.NumeroFrutti = Manager.NumeroFrutti + 1;
                Destroy(gameObject);
            }
        }
    }
}
