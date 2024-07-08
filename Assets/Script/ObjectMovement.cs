using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TipoOggetto
{
    Peperoncino, Caramella
}
public class ObjectMovement : MonoBehaviour
{
    public Tipo Oggetto;
    void Update()
    {
        transform.position += new Vector3(0, -1*Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestroyBox")
        {
            Destroy(gameObject);
        }
    }
}
