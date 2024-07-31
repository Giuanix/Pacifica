using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScorePingPong : MonoBehaviour
{
    public int TotScore; //variabile che contiene lo score totalizzato
    public TMP_Text ScorePartita; //variabile di tipo testo
    public TMP_Text ScoreFinePartita; //variabile che contiene lo score totalizzato a fine partita
    public TMP_Text ScoreInPausa; 
    [SerializeField] private GameObject TestoRecordScore;
    void Start()
    {
        TestoRecordScore.SetActive(false);
        TotScore = 0;
    }
    void Update()
    {
        ScorePartita.text = TotScore.ToString();
        ScoreFinePartita.text = TotScore.ToString();
        ScoreInPausa.text = TotScore.ToString();

        //Funzione per il salvataggio del nuovo record
        if(TotScore >= RecordScore.RecordScorePingPong)
        {
            TestoRecordScore.SetActive(true);
            RecordScore.RecordScorePingPong = TotScore;
            PlayerPrefs.SetFloat("MaxScorePingPong", TotScore);
        }
    }
}
