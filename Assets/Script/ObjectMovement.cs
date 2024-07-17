using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectMovement : MonoBehaviour
{
    public float SpeedObject = -1f;
    public SlotSalvataggioSpeedObject Manager;
    void Start()
    {
        Manager = GameObject.Find("GameManagerMinigiocoCaramelle").GetComponent<SlotSalvataggioSpeedObject>();
    }
    void Update()
    {
        SpeedObject = Manager.SpeedObjectModificato;
        transform.position += new Vector3(0, SpeedObject*Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestroyBox")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
