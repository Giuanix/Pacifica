using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCasse : MonoBehaviour
{
    public int TotScore; //variabile che contiene lo score totalizzato
    public TMP_Text ScorePartita; //variabile di tipo testo
    public TMP_Text ScoreFinePartita;
    public TMP_Text ScoreInPausa; 
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
        ScoreInPausa.text = TotScore.ToString();

        if(TotScore >= RecordScore.RecordScoreCasse)
        {
            TestoRecordScore.SetActive(true);
            RecordScore.RecordScoreCasse = TotScore;
            PlayerPrefs.SetFloat("MaxScoreCasse", TotScore);
        }
    }
}
