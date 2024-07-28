using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloGameOver : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject MinigiocoCasse;
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello;
    public void AttivaGameOver()
    {
        AudioLivello.Stop();
        AudioGameOver.Play();
        Time.timeScale = 0f;
        GameOver.SetActive(true);
        MinigiocoCasse.SetActive(false);
    }
}
