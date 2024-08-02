using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //variabile che contiene la velocità dell'oggetto
    public float SpeedObject = -1f;

    //variabile che contiene il manager dello slot di salvataggio della velocità modificata
    public SlotSalvataggioSpeedObject Manager;
    void Start()
    {
        //assegna il manager all'oggetto appena spawna
        Manager = GameObject.Find("GameManagerMinigiocoCaramelle").GetComponent<SlotSalvataggioSpeedObject>();
    }
    void Update()
    {
        //la velocità modificata diventa la nuova velocità dell'oggetto
        SpeedObject = Manager.SpeedObjectModificato;

        //la riga fa muovere l'oggetto verso il basso alla veloctà indicata
        transform.position += new Vector3(0, SpeedObject * Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        //se l'oggetto collide con la destroybox o il player esso viene distrutto
        if (col.gameObject.tag == "DestroyBox" || col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
