using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectMovement : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(0, -1.8f*Time.deltaTime, 0);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "DestroyBox")
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
