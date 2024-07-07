using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMinigiocoCasse : MonoBehaviour
{
    public Image BarraTimerMinigiocoCassa;
    public float TimerMinigiocoCassa;
    public float MaxTimerTimerMinigiocoCassa;
    void Start()
    {
        TimerMinigiocoCassa = MaxTimerTimerMinigiocoCassa;
    }
    void Update()
    {
        TimerMinigiocoCassa -= Time.deltaTime;
        BarraTimerMinigiocoCassa.fillAmount =(float)TimerMinigiocoCassa/MaxTimerTimerMinigiocoCassa;

        if(TimerMinigiocoCassa <= 0f)
        {
            Debug.Log("Oe");
        }
    }
}
