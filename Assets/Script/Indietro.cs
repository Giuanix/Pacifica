using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indietro : MonoBehaviour
{
    [SerializeField] private GameObject Schermata1;
    [SerializeField] private GameObject Schermata2;

    public void TornaIndietro()
    {
        Schermata1.SetActive(false);
        Schermata2.SetActive(false);
    }
}
