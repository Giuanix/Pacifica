using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioControl : MonoBehaviour
{
    [SerializeField] private Sprite AudioOnImage;
    [SerializeField] private Sprite AudioOffImage;
    [SerializeField] private Button button;
    [SerializeField] private AudioMixer Mixer;
    private float VolumeMin = -80;
    private float VolumeMax = 0;
    private float VolumeAttuale;
    private bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("VolGenerale"))
        {
            LoadVolume();
        }
    }
    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = AudioOffImage;
            isOn = false;
            Mixer.SetFloat("VolGenerale",VolumeMin);
            VolumeAttuale = VolumeMin;
            PlayerPrefs.SetFloat("VolGenerale",VolumeAttuale);
        }
        else
        {
            button.image.sprite = AudioOnImage;
            isOn = true;
            Mixer.SetFloat("VolGenerale",VolumeMax);
            VolumeAttuale = VolumeMax;
            PlayerPrefs.SetFloat("VolGenerale",VolumeAttuale);
        }
    }

    public void LoadVolume()
    {
        VolumeAttuale = PlayerPrefs.GetFloat("VolGenerale");
        if(VolumeAttuale < 0)
        {
            button.image.sprite = AudioOffImage;
            isOn = false;
            Mixer.SetFloat("VolGenerale",VolumeMin);
        }
        else
        {
            button.image.sprite = AudioOnImage;
            isOn = true;
            Mixer.SetFloat("VolGenerale",VolumeMax);
        }
    }
}
