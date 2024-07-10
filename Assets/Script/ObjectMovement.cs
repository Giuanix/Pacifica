using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectMovement : MonoBehaviour
{
    public float SpeedObject = -1f;
    private float Timer;
    [SerializeField] private float MaxTimer;
    public SlotSalvataggioSpeedObject Manager;
    void Start()
    {
        GameObject.Find("GameManagerMinigiocoCaramelle").GetComponent<SlotSalvataggioSpeedObject>();
        Timer = MaxTimer;
        SpeedObject = Manager.SpeedObjectModificato;
    }
    void Update()
    {
        Timer = Timer - Time.deltaTime;
        if(Timer <= 0)
        {
            SpeedObject = SpeedObject - 0.1f;
            Manager.SpeedObjectModificato = SpeedObject;
            Timer = MaxTimer;
        }

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
