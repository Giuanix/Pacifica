using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCaramelle : MonoBehaviour
{
    public GameObject Caramella;
    public GameObject Peperoncino;
    public GameObject PowerUp;
    public GameObject MinigiocoCaramelle;
    public bool doOnce = false;
    public float RandomNum = 0;
    public float MaxSpawnTimer;
    private float SpawnTimer;
    public float MinCadenzaTimer;
    public float MaxCadenzaTimer;
    private float CadenzaTimer;
    [SerializeField] private float CadutaPowerUp;

    public SlotSalvataggioSpeedObject Manager;

    void Start()
    {
        CadenzaTimer = MaxCadenzaTimer;
    }
    void Update()
    {
        CadenzaTimer = CadenzaTimer - Time.deltaTime;
        SpawnTimer = SpawnTimer - Time.deltaTime;

        if (SpawnTimer <= 0)
        {
            SpawnObjectRandom();
            SpawnTimer = MaxSpawnTimer;
        }

        if(MaxSpawnTimer > 1)
        {
            if (CadenzaTimer <= 0)
            {
                MaxSpawnTimer = MaxSpawnTimer - 0.5f;
                CadenzaTimer = MaxCadenzaTimer;
            }
        }
        if(Manager.SpeedObjectModificato == CadutaPowerUp && !doOnce)
        {
            SpawnPowerUp();
            doOnce = true;
        }
    }
    void SpawnObjectRandom()
    {
        for (int i = 0; i < 1; i++)
        {
            RandomNum = Random.Range(1, 3);
            Vector3 randomPos = new Vector3(Random.Range(-2.2f, 2.2f), 8, 0);
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
    void SpawnPowerUp()
    {
        Vector3 randomPos = new Vector3(Random.Range(-2.2f, 2.2f), 8, 0);
        Instantiate(PowerUp, randomPos, Quaternion.identity);
    }
}
