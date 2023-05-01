using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    [SerializeField] string _volumeParameter = "MusicVolume";
    [SerializeField] AudioMixer _mixer;
    [SerializeField] Slider _slider;
    [SerializeField] float _multiplier = 30f;
    [SerializeField] private Toggle _toggle;
    private bool _disableToggleEvent;

    private void Awake()
    {
        _slider.onValueChanged.AddListener(HandleSliderValueChange);
        _toggle.onValueChanged.AddListener(HandleToggleValueChange);
    }

    private void HandleToggleValueChange(bool enableSound)
    {
        if (_disableToggleEvent)
            return;

        if (enableSound)
            _slider.value = _slider.maxValue;
        else
            _slider.value = _slider.minValue;
    }

    private void HandleSliderValueChange(float value)
    {
        _mixer.SetFloat(_volumeParameter, Mathf.Log10(value) * _multiplier);
        _disableToggleEvent = true;
        _toggle.isOn = _slider.value > _slider.minValue;
        _disableToggleEvent = false;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(_volumeParameter, _slider.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeParameter, _slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
