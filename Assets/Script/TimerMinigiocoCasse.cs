using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMinigiocoCasse : MonoBehaviour
{
    [SerializeField] private Image BarraTimerMinigiocoCassa;
    private float TimerMinigiocoCassa;
    [SerializeField] private float MaxTimerMinigiocoCassa;
    void Start()
    {
        TimerMinigiocoCassa = MaxTimerMinigiocoCassa;
    }
    void Update()
    {
        TimerMinigiocoCassa -= Time.deltaTime;
        BarraTimerMinigiocoCassa.fillAmount =(float)TimerMinigiocoCassa/MaxTimerMinigiocoCassa;

        if(TimerMinigiocoCassa <= 0f)
        {
            Debug.Log("Oe");
        }
    }
}
