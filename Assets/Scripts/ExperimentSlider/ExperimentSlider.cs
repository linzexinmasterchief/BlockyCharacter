using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum SliderType
{
    MaxVelocityX,
    MaxVelocityY,
    AccelerationTimeX,
    AccelerationTimeY
}

public class ExperimentSlider : MonoBehaviour
{
    public float min;
    public float max;

    public SliderType sliderType;
    public GameObject vcam;
    public TMP_Text text;

    private Slider slider;
    private CinemachineFreeLook cmFreelook;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        cmFreelook = vcam.GetComponent<CinemachineFreeLook>();
        text.text = (min + slider.value * max).ToString();
    }

    // Update is called once per frame
    public void OnValueChange()
    {
        Debug.Log(sliderType);
        float final_value = min + slider.value * max;
        text.text = final_value.ToString();
        switch (sliderType)
        {
            case SliderType.MaxVelocityX:
                cmFreelook.m_XAxis.m_MaxSpeed = final_value;

                Debug.Log(cmFreelook.m_XAxis.m_MaxSpeed); 
                break;
            case SliderType.MaxVelocityY:
                cmFreelook.m_YAxis.m_MaxSpeed = final_value;
                break;
            case SliderType.AccelerationTimeX:
                cmFreelook.m_XAxis.m_AccelTime = final_value;
                break;
            case SliderType.AccelerationTimeY:
                cmFreelook.m_YAxis.m_AccelTime = final_value;
                break;
        }
    }
}
