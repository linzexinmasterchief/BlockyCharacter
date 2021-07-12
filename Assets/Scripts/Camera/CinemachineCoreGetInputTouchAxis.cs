using Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CinemachineCoreGetInputTouchAxis : MonoBehaviour
{

    public float TouchSensitivity_x;
    public float TouchSensitivity_y;
    private Touch[] touches;

    // Use this for initialization
    void Start()
    {
        CinemachineCore.GetInputAxis = GetInputAxis;
    }

    float GetInputAxis(string axisName)
    {
        touches = Input.touches;
        switch (axisName)
        {

            case "Mouse X":
                
                if (Input.touchCount > 0)
                {
                    for (int i = 0; i < touches.Length; i++)
                    {
                        if (UnityEngine.Screen.width / 2 < touches[i].position.x)
                        {
                            return touches[i].deltaPosition.x * TouchSensitivity_x;
                        }
                    }
                    return 0f;
                }
                else
                {
                    return Input.GetAxis(axisName);
                    //return 0f;
                }

            case "Mouse Y":
                if (Input.touchCount > 0)
                {
                    for (int i = 0; i < touches.Length; i++)
                    {
                        if (UnityEngine.Screen.width / 2 < touches[i].position.x)
                        {
                            return touches[i].deltaPosition.y * TouchSensitivity_y;
                        }
                    }
                    return 0f;
                }
                else
                {
                    return Input.GetAxis(axisName);
                    //return 0f;
                }

            default:
                Debug.LogError("Input <" + axisName + "> not recognyzed.", this);
                break;
        }

        return 0f;
    }

}