using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource BottonClic;
    public void TornaAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        BottonClic.Play();
    }
}
