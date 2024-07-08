using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFrutta : MonoBehaviour
{
    public GameObject Mela;
    public GameObject Pera;
    public GameObject Banana;
    public float Radius = 1;
    public float RandomNum = 0;

    public Inventory Manager;
    void Start()
    {
        if(Manager.MinigiocoCasse == true)
        {
            SpawnObjectRandom();
        }
    }
    void SpawnObjectRandom()
    {
        for (int i = 0; i < 10; i++)
        {
            RandomNum = Random.Range(1,4);
            Vector3 randomPos = Random.insideUnitCircle * Radius;
            if (RandomNum == 1)
            {
                Instantiate(Mela, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 2)
            {
                Instantiate(Pera, randomPos, Quaternion.identity);
            }
            else if(RandomNum == 3)
            {
                Instantiate(Banana, randomPos, Quaternion.identity);
            }
        }
    }
}
