using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _sliderTotalVolume;
    [SerializeField] private Slider _sliderButtonVolume;
    [SerializeField] private Slider _sliderBackgroundVolume;

    [SerializeField] private AudioSource Button1Sound;
    [SerializeField] private AudioSource Button2Sound;
    [SerializeField] private AudioSource Button3Sound;

    private float _minVolume = -80;
    private float _maxVolume = 0;
    private float _masterVolume = -10;

    private bool _masterMixerMute = true;

    private void Start()
    {
        _sliderTotalVolume.minValue = _minVolume;
        _sliderTotalVolume.maxValue = _maxVolume;
        _sliderTotalVolume.value = _masterVolume;

        _sliderButtonVolume.minValue = _minVolume;
        _sliderButtonVolume.maxValue = _maxVolume;
        _sliderButtonVolume.value = _masterVolume;

        _sliderBackgroundVolume.minValue = _minVolume;
        _sliderBackgroundVolume.maxValue = _maxVolume;
        _sliderBackgroundVolume.value = _masterVolume;
    }

    public void OnOffMusic()
    {
        if (_masterMixerMute == false)
        {
            _mixer.audioMixer.SetFloat("MasterVolume", _masterVolume);
            _masterMixerMute = true;
        }
        else
        {
            _mixer.audioMixer.SetFloat("MasterVolume", _minVolume);
            _masterMixerMute = false;
        }
    }

    public void ChangeTotalVolume()
    {
        float volume = _sliderTotalVolume.value;

        if (_masterMixerMute == true)
            _mixer.audioMixer.SetFloat("MasterVolume", volume);
    }

    public void ChangeButtonVolume()
    {
        float volume = _sliderButtonVolume.value;

        _mixer.audioMixer.SetFloat("UIVolume", volume);
    }

    public void ChangeBackgroundVolume()
    {
        float volume = _sliderBackgroundVolume.value;

        _mixer.audioMixer.SetFloat("MusicVolume", volume);
    }

    public void OnClickButton1()
    {
        Button1Sound.Play();
    }

    public void OnClickButton2()
    {
        Button2Sound.Play();
    }

    public void OnClickButton3()
    {
        Button3Sound.Play();
    }
}
