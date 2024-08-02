using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class RecordScore : MonoBehaviour
{
    //variabili statiche che contengono i record score dei minigiochi
    public static float RecordScoreCaramelle;
    public static float RecordScorePingPong;
    public static float RecordScoreCasse;

    //variabili che contengono i riferimenti ai txt dei record
    public TMP_Text TXTRecordScoreCaramelle;
    public TMP_Text TXTRecordScorePingPong;
    public TMP_Text TXTRecordScoreCasse;
    void Start()
    {
        if (TXTRecordScoreCaramelle == null)
        {
            return;
        }

        //carica i valori record
        if (PlayerPrefs.HasKey("MaxScoreCasse") || PlayerPrefs.HasKey("MaxScoreCaramelle") || PlayerPrefs.HasKey("MaxScorePingPong"))
        {
            LoadScore();
        }

        //stampa i valori record nella schermata
        TXTRecordScoreCaramelle.text = RecordScoreCaramelle.ToString();
        TXTRecordScorePingPong.text = RecordScorePingPong.ToString();
        TXTRecordScoreCasse.text = RecordScoreCasse.ToString();
    }

    //funzione che gestisce il caricamento dei valori record nello slot di salavtaggio dei playerpref
    public void LoadScore()
    {
        RecordScoreCaramelle = PlayerPrefs.GetFloat("MaxScoreCaramelle", 0);
        RecordScorePingPong = PlayerPrefs.GetFloat("MaxScorePingPong", 0);
        RecordScoreCasse = PlayerPrefs.GetFloat("MaxScoreCasse", 0);
    }
}
