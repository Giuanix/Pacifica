using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerMinigiocoCasse : MonoBehaviour
{
    [SerializeField] private Image BarraTimerMinigiocoCassa;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject MinigiocoCasse;
    public float TimerMinigiocoCassa;
    public float MaxTimerMinigiocoCassa;
    void Start()
    {
        Time.timeScale = 1f;
        GameOver.SetActive(false);
        MinigiocoCasse.SetActive(true);
        TimerMinigiocoCassa = MaxTimerMinigiocoCassa;
    }
    void Update()
    {
        TimerMinigiocoCassa -= Time.deltaTime;
        BarraTimerMinigiocoCassa.fillAmount =(float)TimerMinigiocoCassa/MaxTimerMinigiocoCassa;

        if(TimerMinigiocoCassa <= 0f)
        {
            Time.timeScale = 0f;
            GameOver.SetActive(true);
            MinigiocoCasse.SetActive(false);
        }
    }
}
