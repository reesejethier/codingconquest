using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider slider;
    public string setting;

    // Start is called before the first frame update
    void Start()
    {
        Load();
    }


    public void ChangeVolume(float val)
    {
        //AudioListener.volume = val;
        PlayerPrefs.SetFloat(setting + "Volume", val);
        Save();
    }

    private void Load()
    {
        slider.value = PlayerPrefs.GetFloat(setting + "Volume");
       
    }

    private void Save()
    {
        PlayerPrefs.SetFloat(setting + "Volume", slider.value);
    }
}
