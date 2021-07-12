using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum component_states
{
    active,
    non_active
}
public class VisibleOnTouch : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public component_states default_state;
    private Image image;
    private Color original_color;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        original_color = image.color;
        switch (default_state)
        {
            case component_states.active:
                image.color = original_color;
                break;
            case component_states.non_active:
                image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = original_color;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0);
    }

}
