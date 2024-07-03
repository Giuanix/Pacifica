using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntatore : MonoBehaviour
{
    public Vector2 direction { get; private set; }
    private Camera mainCamera;
    private Collider2D coll;
    private TrailRenderer trail;
    public float force = 5f;
    public float minVelocity = 0.1f;
    private bool slicing;

    // Start is called before the first frame update
    private void Awake()
    {
        mainCamera = Camera.main;
        coll = GetComponent<CircleCollider2D>();
        trail = GetComponentInChildren<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartSlice();
        }
        else if(Input.GetMouseButtonUp(0))
        {
            StopSlice();
        }
        else if(slicing)
        {
            ContinueSlice();
        }
    }

    private void StartSlice()
    {
        Vector2 position = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = position;

        slicing = true;
        float velocity = direction.magnitude / Time.deltaTime;
        coll.enabled = velocity > minVelocity;
        trail.enabled = true;
        trail.Clear();
    }

    private void StopSlice()
    {
        slicing = false;
        coll.enabled = false;
        trail.enabled = false;
    }

    private void ContinueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = 0f;

        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        coll.enabled = velocity > minVelocity;

        transform.position = newPosition;

    }
}
