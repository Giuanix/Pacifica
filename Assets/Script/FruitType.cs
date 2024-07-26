using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitType : MonoBehaviour
{
    public Tipo Frutta;
    public ControlloGameOver Manager;
    public ScoreCasse ManagerScore;
    void Start()
    {
        Manager = GameObject.Find("GameManagerMinigiocoCasse").GetComponent<ControlloGameOver>();
        ManagerScore = GameObject.Find("GameManagerMinigiocoCasse").GetComponent<ScoreCasse>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Cassa")
        {
            if(col.gameObject.GetComponent<FruitChest>().Chest1==Frutta || col.gameObject.GetComponent<FruitChest>().Chest2==Frutta)
            {
                ManagerScore.TotScore = ManagerScore.TotScore + 1;
                GestioneProgressione.ValoreAttualeProgressione = GestioneProgressione.ValoreAttualeProgressione + 1;
                PlayerPrefs.SetFloat("Progressi", GestioneProgressione.ValoreAttualeProgressione);
                Destroy(gameObject);
            }
            else
            {
                Manager.AttivaGameOver();
            }
        }
    }
}
