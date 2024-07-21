using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioControl : MonoBehaviour
{
    [SerializeField] private Sprite AudioOnImage;
    [SerializeField] private Sprite AudioOffImage;
    [SerializeField] private Button button;
    [SerializeField] private AudioSource Theme;
    private bool isOn = true;
    // Start is called before the first frame update
    void Start()
    {
        AudioOnImage = button.image.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonClicked()
    {
        if(isOn)
        {
            button.image.sprite = AudioOffImage;
            isOn = false;
            Theme.mute = true;
        }
        else
        {
            button.image.sprite = AudioOnImage;
            isOn = true;
            Theme.mute = false;
        }
    }
}
