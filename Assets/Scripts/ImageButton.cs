using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Image image;

    public Color normalColor = Color.white;
    public Color hoveredColor = Color.white;
    public Color clickedColor = Color.white;

    public UnityEvent onMouseEnter = new UnityEvent();
    public UnityEvent onMouseExit = new UnityEvent();
    public UnityEvent onMouseClick = new UnityEvent();

    bool hovered = false;

    void Update()
    {
        if (hovered)
        {
            if (Input.GetMouseButton(0))
            {
                image.color = Color.Lerp(image.color, clickedColor, 0.1f);
            }
            else image.color = Color.Lerp(image.color, hoveredColor, 0.1f);
        }
        else image.color = Color.Lerp(image.color, normalColor, 0.1f);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
        onMouseEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
        onMouseExit.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        onMouseClick.Invoke();
    }

    void Reset()
    {
        try
        {
            image = GetComponent<Image>();
        }
        catch
        {
            print(name + " needs an Image Component!");
        }
    }
}
