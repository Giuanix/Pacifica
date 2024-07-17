using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PgcaramelleMovement : MonoBehaviour
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;
    public GameObject MinigiocoCaramelle;
    public GameObject SpawnCaramelle;
    public GameObject GameOver;
    private bool SwitchScale = false;
    public float MaxSwitchTimer;
    private float SwitchTimer;
    void Start()
    {
        Time.timeScale = 1f;
        MinigiocoCaramelle.SetActive(true);
        SpawnCaramelle.SetActive(true);
        GameOver.SetActive(false);
    }
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if(SwitchScale == true)
        {
            SwitchTimer = SwitchTimer - Time.deltaTime;
            if(SwitchTimer <= 0)
            {
                transform.localScale = new Vector3(1f, 1f, 0);
                SwitchScale = false;
            }
        }
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = new Vector3(Input.mousePosition.x, 300f, 0);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            isBeingHeld = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Caramella")
        {
            Debug.Log("Oee");
        }
        else if(col.gameObject.tag == "Peperoncino")
        {
            Time.timeScale = 0f;
            MinigiocoCaramelle.SetActive(false);
            SpawnCaramelle.SetActive(false);
            GameOver.SetActive(true);
        }
        else if(col.gameObject.tag == "PowerUp")
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 0);
            SwitchTimer = MaxSwitchTimer;
            SwitchScale = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
