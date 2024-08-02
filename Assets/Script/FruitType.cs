using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitType : MonoBehaviour
{
    //variabile che richiama la classe astratta "tipo"
    public Tipo Frutta;
    //variabile contenente il manager del controllo del game over
    public ControlloGameOver Manager;
    //variabile contenente il manager dello score
    public ScoreCasse ManagerScore;
    void Start()
    {
        //assegnamo alla frutta il controllo del game over e il contatore dello score
        Manager = GameObject.Find("GameManagerMinigiocoCasse").GetComponent<ControlloGameOver>();
        ManagerScore = GameObject.Find("GameManagerMinigiocoCasse").GetComponent<ScoreCasse>(); 
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        /*Se la frutta impatta con la cassa giusta:
        1) aumenta di 1 lo score
        2) viene aumentato il valore generale di progressione per lo sblocco dei nuovi minigiochi
        3) viene settato quel valore nel playerpref
        4) l'oggetto viene distrutto */
        if(col.gameObject.tag == "Cassa")
        {
            if(col.gameObject.GetComponent<FruitChest>().Chest1==Frutta || col.gameObject.GetComponent<FruitChest>().Chest2==Frutta)
            {
                ManagerScore.TotScore = ManagerScore.TotScore + 1;
                GestioneProgressione.ValoreAttualeProgressione = GestioneProgressione.ValoreAttualeProgressione + 1;
                PlayerPrefs.SetFloat("Progressi", GestioneProgressione.ValoreAttualeProgressione);
                Destroy(gameObject);
            }

            //Se l'impatto non avviene con la cassa giusta viene richiamata la funzione di game over
            else
            {
                Manager.AttivaGameOver();
            }
        }
    }
}
