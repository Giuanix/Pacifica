using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCaramelle : MonoBehaviour
{
    //variabili contenentei gli oggetti che spawnano nella scena: caramella, peperoncino e power up
    [SerializeField] private GameObject Caramella;
    [SerializeField] private GameObject Peperoncino;
    [SerializeField] private GameObject PowerUp;

    //variabile che contiene la schermata del minigioco
    [SerializeField] private GameObject MinigiocoCaramelle;

    //variabile che contiene il numero random
    [SerializeField] private float RandomNum = 0;

    //variabile che contiene il timer massimo di spawn
    [SerializeField] private float MaxSpawnTimer;

    //variabile che contiene il timer di spawn
    private float SpawnTimer;

    //variabili che contengono i valori massimi e minimi del timer della cadenza di spawn
    [SerializeField] private float MinCadenzaTimer;
    [SerializeField] private float MaxCadenzaTimer;

    //variabile contenente il timer della cadenza
    private float CadenzaTimer;

    //variabile che contiene il limite di spawn sull'asse y
    [SerializeField] private float LimiteSpawnSuAsseY;

    //variabile che contiene il limite di spawn degli oggetti
    [SerializeField] private float LimiteSpawnObject;

    //variabile che contiene il valore di quando deve cadere il power up
    [SerializeField] private float CadutaPowerUp;

    //variabile che contiene il manager dello slot di salvataggio della velocità modificata
    public SlotSalvataggioSpeedObject Manager;
    void Start()
    {
        //il timer viene settato al massimo
        CadenzaTimer = MaxCadenzaTimer;
    }
    void Update()
    {
        //iniziano a scalare i timer
        CadenzaTimer = CadenzaTimer - Time.deltaTime;
        SpawnTimer = SpawnTimer - Time.deltaTime;

        //spawn dell'oggetto
        if (SpawnTimer <= 0)
        {
            SpawnObjectRandom();
            SpawnTimer = MaxSpawnTimer;
        }

        if(MaxSpawnTimer > 1)
        {
            //se la cadenza del timer è uguale a zero lo spawn timer diminuisce di 0.5f
            if (CadenzaTimer <= 0)
            {
                MaxSpawnTimer = MaxSpawnTimer - 0.5f;
                CadenzaTimer = MaxCadenzaTimer;
            }
        }

        //Quando la velocità dell'oggetto è uguale al valore della caduta del power up spawna il power up
        if(Manager.SpeedObjectModificato == CadutaPowerUp)
        {
            SpawnPowerUp();
            LimiteSpawnObject = LimiteSpawnObject + 1;
            CadutaPowerUp = CadutaPowerUp + (-2.0f);
            if(LimiteSpawnSuAsseY != 12f)
            {
                LimiteSpawnSuAsseY = LimiteSpawnSuAsseY - 2f;
            }
        }
    }
    //funzione che gestisce lo spawn random degli oggetti
    void SpawnObjectRandom()
    {
        for (int i = 0; i < LimiteSpawnObject; i++)
        {
            RandomNum = Random.Range(1, 3);
            Vector3 randomPos = new Vector3(Random.Range(-2.2f, 2.2f),Random.Range(7f, LimiteSpawnSuAsseY), 0);
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

    //funzione per fa spawnare il power up
    void SpawnPowerUp()
    {
        Vector3 randomPos = new Vector3(Random.Range(-2.2f, 2.2f),Random.Range(8f, 12f), 0);
        Instantiate(PowerUp, randomPos, Quaternion.identity);
    }
}
