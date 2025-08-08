using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;
    public string exposedParam = "MasterVolume";

    private bool updating = false;

    void Start()
    {
        if (slider == null) slider = GetComponent<Slider>();


        slider.onValueChanged.AddListener(OnSliderChanged);
    }

    void OnSliderChanged(float value)
    {
        if (updating) return;

        SetVolume(value);

        // Sync other sliders in the scene
        updating = true;
        foreach (var vc in FindObjectsOfType<VolumeControl>())
        {
            if (vc != this)
                vc.slider.value = value;
        }
        updating = false;
    }

    public void SetVolume(float value)
    {
        float volumeInDb = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20;
        mixer.SetFloat(exposedParam, volumeInDb);
    }
}
