using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider slider;

    private bool suppressChange = false;

    private void Awake()
    {
        if (slider != null)
        {
            slider.onValueChanged.AddListener(OnSliderChanged);
        }
        else
        {
            Debug.LogWarning("VolumeController: SLIDER is niet gekoppeld!");
        }

        if (mixer == null)
        {
            Debug.LogWarning("VolumeController: MIXER is niet gekoppeld!");
        }
    }

    public void Init()
    {
        if (mixer == null || slider == null)
            return;

        float value;
        if (mixer.GetFloat("MasterVolume", out value))
        {
            float linear = Mathf.Pow(10f, value / 20f);
            suppressChange = true;
            slider.value = linear;
            suppressChange = false;
        }
    }

    private void OnSliderChanged(float value)
    {
        if (suppressChange || mixer == null)
            return;

        if (value <= 0.0001f)
            mixer.SetFloat("MasterVolume", -80f);
        else
            mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20f);
    }
}