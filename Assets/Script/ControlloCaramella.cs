using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlloCaramella : MonoBehaviour
{
    public GameObject MinigiocoCaramelle;
    public GameObject SpawnCaramelle;
    public GameObject GameOver;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Caramella")
        {
            Time.timeScale = 0f;
            GameOver.SetActive(true);
            MinigiocoCaramelle.SetActive(false);
            SpawnCaramelle.SetActive(false);
        }
    }
}
