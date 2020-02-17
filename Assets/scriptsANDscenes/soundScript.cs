using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class soundScript : MonoBehaviour
{
    private static readonly string SoundPref = "SoundPref";
    public Slider SoundSlider;

    void Update()
    {
        //Stores the rocket volume set by sliders in PlayerPrefs to be used in rocket script
        PlayerPrefs.SetFloat(SoundPref, SoundSlider.value);
    }
}
