using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitType : MonoBehaviour
{
    public Tipo Frutta;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Cassa")
        {
            if(col.gameObject.GetComponent<FruitChest>().Chest1==Frutta ||col.gameObject.GetComponent<FruitChest>().Chest2==Frutta)
            {
                Destroy(gameObject);
            }
        }
    }
}
