using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Tipo
{
    Mela, Pera, Banana
}
public class FruitChest : MonoBehaviour
{
    public Tipo Chest;
    public Inventory Manager;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Frutto")
        {
            Manager.NumeroFrutti = Manager.NumeroFrutti + 1;
        }
    }
}
