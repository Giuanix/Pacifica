using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreCasse : MonoBehaviour
{
    public int TotScore; //variabile che contiene lo score totalizzato
    public TMP_Text ScorePartita; //variabile di tipo testo
    public TMP_Text ScoreFinePartita; //variabile che contiene lo score totalizzato a fine partita
    public TMP_Text ScoreInPausa; //variabile che contiene lo score totalizzato nel menu di pausa
    [SerializeField] private GameObject TestoRecordScore; //variabile che contiene una componente estetica con su scritto "new record"
    void Start()
    {
        //setta il testo estetico "nuovo record" a falso e il totale dello score a zero
        TestoRecordScore.SetActive(false);
        TotScore = 0;
    }
    void Update() 
    {
        //stampa i valori dello score nelle varie schermate di appartenenza
        ScorePartita.text = TotScore.ToString();
        ScoreFinePartita.text = TotScore.ToString();
        ScoreInPausa.text = TotScore.ToString();

        //Funzione per il salvataggio del nuovo record
        if (TotScore >= RecordScore.RecordScoreCasse)
        {
            TestoRecordScore.SetActive(true);
            RecordScore.RecordScoreCasse = TotScore;
            PlayerPrefs.SetFloat("MaxScoreCasse", TotScore);
        }
    }
}
