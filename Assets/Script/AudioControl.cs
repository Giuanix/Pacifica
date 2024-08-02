using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioControl : MonoBehaviour
{
    //variabile contenente lo sprite di audio attivato
    [SerializeField] private Sprite AudioOnImage; 

    //variabile contenente lo sprite di audio disattivato
    [SerializeField] private Sprite AudioOffImage; 

    //variabile contenente il bottone che gestisce l'audio
    [SerializeField] private Button button;

    //variabile contenente l'audio mixer che controlla l'intero pacco audio del gioco
    [SerializeField] private AudioMixer Mixer;

    //variabili per la modifica dell'audio
    private float VolumeMin = -80;
    private float VolumeMax = 0;
    private float VolumeAttuale;
    private bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        //funzione che carica l'ultima impostazione audio selezionata prima della chiusura del gioco
        if(PlayerPrefs.HasKey("VolGenerale"))
        {
            LoadVolume();
        }
    }

    //funzione che gestisce le azioni da intraprendere al click del bottone
    public void ButtonClicked()
    {
        /*se esso viene selezionato:
        1) imposta la sprite di audio disattivato
        2) setta la booleana "isOn" a falso
        3) setta il valore minimo nell volume del mixer
        4) setta il valore attuale uguale al valore di volume minimo
        5) Setta nel playerpref le operazioni eseguite*/
        if(isOn)
        {
            button.image.sprite = AudioOffImage;
            isOn = false;
            Mixer.SetFloat("VolGenerale",VolumeMin);
            VolumeAttuale = VolumeMin;
            PlayerPrefs.SetFloat("VolGenerale",VolumeAttuale);
        }

        /*se esso viene selezionato:
        1) imposta la sprite di audio attivato
        2) setta la booleana "isOn" a vera
        3) setta il valore massimo nell volume del mixer
        4) setta il valore attuale uguale al valore di volume massimo
        5) Setta nel playerpref le operazioni eseguite*/
        else
        {
            button.image.sprite = AudioOnImage;
            isOn = true;
            Mixer.SetFloat("VolGenerale",VolumeMax);
            VolumeAttuale = VolumeMax;
            PlayerPrefs.SetFloat("VolGenerale",VolumeAttuale);
        }
    }

    //azioni eseguite per effettuare il caricamento degli ultimi dati a inizio nuova partita
    public void LoadVolume()
    {
        //prende il valore attuale per eseguire dei controlli
        VolumeAttuale = PlayerPrefs.GetFloat("VolGenerale");

        /*se il valore attuale e minore di 0:
        1) imposta la sprite di audio disattivato
        2) setta la booleana "isOn" a falso
        5) Setta nel playerpref il valore minimo*/
        if(VolumeAttuale < 0)
        {
            button.image.sprite = AudioOffImage;
            isOn = false;
            Mixer.SetFloat("VolGenerale",VolumeMin);
        }
         /*se non lo è:
        1) imposta la sprite di audio attivato
        2) setta la booleana "isOn" a vero
        5) Setta nel playerpref il valore massimo*/
        else
        {
            button.image.sprite = AudioOnImage;
            isOn = true;
            Mixer.SetFloat("VolGenerale",VolumeMax);
        }
    }
}
