using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCaramelle : MonoBehaviour
{
    public float TotScore; //variabile che contiene lo score totalizzato
    public TMP_Text ScorePartita; //variabile di tipo testo
    public TMP_Text ScoreFinePartita; //variabile che contiene lo score totalizzato a fine partita
    [SerializeField] private GameObject TestoRecordScore;
    void Start()
    {
        TestoRecordScore.SetActive(false);
        TotScore = 0;
    }
    void Update() //metodo per implementare lo score e stamparlo nella GUI di gioco
    {
        ScorePartita.text = TotScore.ToString();
        ScoreFinePartita.text = TotScore.ToString();

        //Funzione per il salvataggio del nuovo record
        if(TotScore >= RecordScore.RecordScoreCaramelle)
        {
            TestoRecordScore.SetActive(true);
            RecordScore.RecordScoreCaramelle = TotScore;
            PlayerPrefs.SetFloat("MaxScoreCaramelle", TotScore);
        }
    }
}
