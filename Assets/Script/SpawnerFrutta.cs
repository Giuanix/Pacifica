using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFrutta : MonoBehaviour
{
    [SerializeField] private GameObject Mela;
    [SerializeField] private GameObject Pera;
    [SerializeField] private GameObject Banana;
    [SerializeField] private float Radius = 1;
    private float RandomNum = 0;
    public Inventory Manager;
    void Update()
    {
        if(Manager.MinigiocoCasse == true)
        {
            SpawnObjectRandom();
        }
    }
    public void SpawnObjectRandom()
    {
        for (int i = 0; i < Manager.TotNumeroFrutti; i++)
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
