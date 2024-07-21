using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScorePingPong : MonoBehaviour
{
    public int TotScore; //variabile che contiene lo score totalizzato

    public TMP_Text ScorePartita; //variabile di tipo testo
    public TMP_Text ScoreFinePartita;

    void Start()
    {
        TotScore = 0;
    }
    void Update() //metodo per implementare lo score e stamparlo nella GUI di gioco
    {
        ScorePartita.text = TotScore.ToString();
        ScoreFinePartita.text = TotScore.ToString();

        if(TotScore >= RecordScore.RecordScorePingPong)
        {
            RecordScore.RecordScorePingPong = TotScore;
        }
    }
}
