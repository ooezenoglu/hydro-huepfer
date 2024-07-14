using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudiManager : MonoBehaviour
{
    [SerializeField] Slider soundsSlider;
    [SerializeField] AudioMixer masterMixer;

    private void Start() {
        SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    private void SetVolume(float _value) {
        if(_value < 1) {
            _value = .00001f;
        }

        RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 50f);
    }

    public void SetVolumeFromSlider() {
        SetVolume(soundsSlider.value);
    }
    
    public void RefreshSlider(float _value) {
        soundsSlider.value = _value;
    }

}
