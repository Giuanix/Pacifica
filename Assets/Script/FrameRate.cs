using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    //funzione per settare il frame rate a 120
    void Start()
    {
        Application.targetFrameRate = 120;
    }
}
