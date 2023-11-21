using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorDeSom : MonoBehaviour
{
    [SerializeField] Slider sliderDeVolume;

    void Start()
    {
        if(!PlayerPrefs.HasKey("volumeDaMusica"))
        {
            PlayerPrefs.SetFloat("VolumeDaMusica", 1);
            Load();
        } else {
            Load();
        }
    }

    public void MudarVolume()
    {
        AudioListener.volume = sliderDeVolume.value;
        Save();
    }
    
    private void Load()
    {
        sliderDeVolume.value = PlayerPrefs.GetFloat("VolumeDaMusica");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("VolumeDaMusica", sliderDeVolume.value);
    }
}
