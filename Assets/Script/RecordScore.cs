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

        if (PlayerPrefs.HasKey("MaxScoreCasse") || PlayerPrefs.HasKey("MaxScoreCaramelle") || PlayerPrefs.HasKey("MaxScorePingPong"))
        {
            LoadScore();
        }

        TXTRecordScoreCaramelle.text = RecordScoreCaramelle.ToString();
        TXTRecordScorePingPong.text = RecordScorePingPong.ToString();
        TXTRecordScoreCasse.text = RecordScoreCasse.ToString();
    }
    public void LoadScore()
    {
        RecordScoreCaramelle = PlayerPrefs.GetFloat("MaxScoreCaramelle", 0);
        RecordScorePingPong = PlayerPrefs.GetFloat("MaxScorePingPong", 0);
        RecordScoreCasse = PlayerPrefs.GetFloat("MaxScoreCasse", 0);
    }
}
