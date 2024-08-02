using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSalvataggioSpeedObject : MonoBehaviour
{
    //variabile contenente la velocità modificata
    public float SpeedObjectModificato = -1f;

    //la variabile contiene il valore del timer
    private float Timer;
    //la variabile contiene il valore massimo del timer
    [SerializeField] private float MaxTimer;

    void Start()
    {
        //il timer viene settato al massimo
        Timer = MaxTimer;  
    }
    void Update()
    {
        //quando il timer arriva a 0 la velocità si modifica di -0.2f e il timer viene resettato al massimo
        Timer = Timer - Time.deltaTime;
        if (Timer <= 0)
        {
            SpeedObjectModificato = SpeedObjectModificato - 0.2f;
            Timer = MaxTimer;
        }
    }
}
