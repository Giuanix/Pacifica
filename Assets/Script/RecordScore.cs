using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
public class RecordScore : MonoBehaviour
{
    public static float RecordScoreCaramelle;
    public static float RecordScorePingPong;
    public static float RecordScoreCasse;
    public TMP_Text TXTRecordScoreCaramelle;
    public TMP_Text TXTRecordScorePingPong;
    public TMP_Text TXTRecordScoreCasse;
    void Start()
    {
        if (TXTRecordScoreCaramelle == null)
        {
            return;
        }

        TXTRecordScoreCaramelle.text = RecordScoreCaramelle.ToString();
        TXTRecordScorePingPong.text = RecordScorePingPong.ToString();
        TXTRecordScoreCasse.text = RecordScoreCasse.ToString();

        if(PlayerPrefs.HasKey("GameManagerMenuPrincipale"))
        {
            LoadScore();
        }
    }
    public void LoadScore()
    {
        RecordScoreCaramelle = PlayerPrefs.GetFloat("GameManagerMenuPrincipale");
        RecordScorePingPong = PlayerPrefs.GetFloat("GameManagerMenuPrincipale");
        RecordScoreCasse = PlayerPrefs.GetFloat("GameManagerMenuPrincipale");
    }
}
