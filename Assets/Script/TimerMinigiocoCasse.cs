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
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello;
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
            TimerMinigiocoCassa = MaxTimerMinigiocoCassa;
            Time.timeScale = 0f;
            AudioLivello.Stop();
            AudioGameOver.Play();
            GameOver.SetActive(true);
            MinigiocoCasse.SetActive(false);
        }
    }
}
