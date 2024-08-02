using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//viene creata una classe astratta dove all'interno inseriamo tutti i tipi di frutti da inserire nelle casse
public enum Tipo
{
    Mela, Pera, Banana, MelaGialla, BananaVerde, PeraRossa
}
public class FruitChest : MonoBehaviour
{
    //variabili che richiamano la classe astratta
    public Tipo Chest1;
    public Tipo Chest2;

    //variabile contenente il manager dell'inventario della frutta
    public Inventory Manager;

    /*variabili contenenti le clip audio, di seguito i crediti:
    Audio deposito in cassa: https://freesound.org/people/Strechy/sounds/654251/ */
    [SerializeField] private AudioSource AudioCassa;
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*quando la cassa collide con un frutto:
        1)Riproduce Audio deposito in cassa
        2) incrementa il numero di frutti in inventario*/
        if(col.gameObject.tag == "Frutto")
        {
            AudioCassa.Play();
            Manager.NumeroFrutti = Manager.NumeroFrutti + 1;
        }
    }
}
