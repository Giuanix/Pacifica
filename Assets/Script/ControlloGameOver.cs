using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloGameOver : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject MinigiocoCasse;

    public void AttivaGameOver()
    {
        Time.timeScale = 0f;
        GameOver.SetActive(true);
        MinigiocoCasse.SetActive(false);
    }
}
