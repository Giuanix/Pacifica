using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScorePingPong : MonoBehaviour
{
    public int TotScore; //variabile che contiene lo score totalizzato
    public TMP_Text ScorePartita; //variabile di tipo testo
    public TMP_Text ScoreFinePartita; //variabile che contiene lo score totalizzato a fine partita

    void Start()
    {
        TotScore = 0;
    }
    void Update()
    {
        ScorePartita.text = TotScore.ToString();
        ScoreFinePartita.text = TotScore.ToString();

        //Funzione per il salvataggio del nuovo record
        if(TotScore >= RecordScore.RecordScorePingPong)
        {
            RecordScore.RecordScorePingPong = TotScore;
            PlayerPrefs.SetFloat("MaxScorePingPong", TotScore);
        }
    }
}
