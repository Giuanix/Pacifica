using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloCaramella : MonoBehaviour
{
    public GameObject MinigiocoCaramelle;
    public GameObject SpawnCaramelle;
    public GameObject GameOver;
    [SerializeField] private AudioSource AudioGameOver;
    [SerializeField] private AudioSource AudioLivello; 
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Caramella")
        {
            AudioLivello.Stop();
            AudioGameOver.Play();
            Time.timeScale = 0f;
            GameOver.SetActive(true);
            MinigiocoCaramelle.SetActive(false);
            SpawnCaramelle.SetActive(false);
        }
    }
}
