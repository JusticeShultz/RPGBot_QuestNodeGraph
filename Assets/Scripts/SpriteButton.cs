using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class SpriteButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SpriteRenderer spriteRenderer;

    public Color normalColor = Color.white;
    public Color hoveredColor = Color.white;
    public Color clickedColor = Color.white;

    public UnityEvent onMouseEnter = new UnityEvent();
    public UnityEvent onMouseExit = new UnityEvent();
    public UnityEvent onMouseClick = new UnityEvent();

    bool hovered = false;

    void Update()
    {
        if(hovered)
        {
            if (Input.GetMouseButton(0))
            {
                spriteRenderer.color = Color.Lerp(spriteRenderer.color, clickedColor, 0.1f);
            }
            else spriteRenderer.color = Color.Lerp(spriteRenderer.color, hoveredColor, 0.1f);
        } else spriteRenderer.color = Color.Lerp(spriteRenderer.color, normalColor, 0.1f);
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
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        catch
        {
            print(name + " needs a Sprite Renderer!");
        }
    }
}
