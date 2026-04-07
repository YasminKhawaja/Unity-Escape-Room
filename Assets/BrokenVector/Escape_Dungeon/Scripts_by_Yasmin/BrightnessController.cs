using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class BrightnessController : MonoBehaviour
{
    public Volume globalVolume;
    public Slider slider;

    private ColorAdjustments colorAdjustments;

    private void Awake()
    {
        if (globalVolume == null || slider == null)
        {
            Debug.LogError("BrightnessController: references missing");
            return;
        }

        if (!globalVolume.profile.TryGet(out colorAdjustments))
        {
            Debug.LogError("BrightnessController: ColorAdjustments not found");
            return;
        }

        slider.onValueChanged.AddListener(SetBrightness);

        // init slider
        slider.value = colorAdjustments.postExposure.value;
    }

    private void SetBrightness(float value)
    {
        colorAdjustments.postExposure.value = value;
    }
}
