using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class RecordScore : MonoBehaviour
{
    public static float RecordScoreCaramelle;
    public static float RecordScorePingPong;
    public static float RecordScoreCasse;
    public TMP_Text TXTRecordScoreCaramelle;
    public TMP_Text TXTRecordScorePingPong;
    public TMP_Text TXTRecordScoreCasse;
    void Update()
    {
        TXTRecordScoreCasse.text = RecordScoreCaramelle.ToString();
        TXTRecordScorePingPong.text = RecordScorePingPong.ToString();
        TXTRecordScoreCasse.text = RecordScoreCasse.ToString();
    }
}
