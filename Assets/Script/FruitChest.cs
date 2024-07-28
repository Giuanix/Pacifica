using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Tipo
{
    Mela, Pera, Banana, MelaGialla, BananaVerde, PeraRossa
}
public class FruitChest : MonoBehaviour
{
    public Tipo Chest1;
    public Tipo Chest2;
    public Inventory Manager;
    [SerializeField] private AudioSource AudioCassa;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Frutto")
        {
            AudioCassa.Play();
            Manager.NumeroFrutti = Manager.NumeroFrutti + 1;
        }
    }
}
