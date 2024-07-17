using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private GameObject Minigioco;
    [SerializeField] private float Speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject Pg;
    [SerializeField] private float ContatoreDiminuisciPlayer = 0;
    private bool AumentoSpeed = true;
    private bool DiminuisciPlayer = false;
    private float x;
    private float y;
    [SerializeField] private float DimensioneX = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        Launch();
    }
    private void Update()
    {
        if(Speed == 8f)
        {
            AumentoSpeed = false;
            DiminuisciPlayer = true;
        }

        if(ContatoreDiminuisciPlayer == 5)
        {
            AumentoSpeed = false;
            DiminuisciPlayer = true;
        }
    }
    private void Launch()
    {
        x = Random.Range(0,2) == 0 ? -1 : 1;
        y = Random.Range(0,2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(Speed * x, Speed * y);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && AumentoSpeed == true)
        {
            Speed = Speed + 0.5f;
            rb.velocity = new Vector2(Speed + x, Speed + y);
        }
        if (col.gameObject.tag == "Player" && DiminuisciPlayer == true)
        {
            DimensioneX = DimensioneX - 0.1f;
            Pg.transform.localScale = new Vector3(DimensioneX, 0.3f, 0);
            ContatoreDiminuisciPlayer = ContatoreDiminuisciPlayer + 1;
        }
        if (col.gameObject.tag == "DestroyBox")
        {
            Time.timeScale = 0f;
            
        }
    }
}
