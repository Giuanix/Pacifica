using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotSalvataggioSpeedObject : MonoBehaviour
{
    public float SpeedObjectModificato = -1f;
    private float Timer;
    public float MaxTimer;

    void Update()
    {
        Timer = Timer - Time.deltaTime;
        if (Timer <= 0)
        {
            SpeedObjectModificato = SpeedObjectModificato - 0.1f;
            Timer = MaxTimer;
        }
    }
}
