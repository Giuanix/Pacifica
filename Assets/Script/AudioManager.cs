using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioSource BottonClic;
    static public void Clic()
    {
        BottonClic.Play();
    }
}
