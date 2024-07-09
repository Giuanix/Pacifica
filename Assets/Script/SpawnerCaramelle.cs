using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCaramelle : MonoBehaviour
{
    public GameObject Caramella;
    public GameObject Peperoncino;
    public GameObject MinigiocoCaramelle;
    public float RandomNum = 0;
    public float MaxTimer;
    private float Timer;
    void Update()
    {
        Timer = Timer - Time.deltaTime;
        if(Timer <= 0)
        {
            SpawnObjectRandom();
            Timer = MaxTimer;
        }
    }
    void SpawnObjectRandom()
    {
        for (int i = 0; i < 2; i++)
        {
            RandomNum = Random.Range(1, 3);
            //Vector3 randomPos = Random.insideUnitCircle * Radius;
            Vector3 randomPos = new Vector3(Random.Range(-2.2f, 2.2f),Random.Range(5, 20), 0);
            if (RandomNum == 1)
            {
                Instantiate(Caramella, randomPos, Quaternion.identity);
            }
            else if (RandomNum == 2)
            {
                Instantiate(Peperoncino, randomPos, Quaternion.identity);
            }
        }
    }
}
