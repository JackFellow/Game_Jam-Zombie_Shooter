using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Slider;

    private void Update()
    {
        Slider.onValueChanged.AddListener((v) => {

            Slider.value = v;


        });


    }
    public void VolumeMusic()
    {
        AudioManager.instance.MusicVolumeAmount(Slider.value);
    }

    public void VolumeAudio()
    {
        AudioManager.instance.SFXVolumeAmount(Slider.value);
    }
}