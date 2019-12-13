using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isMoving = false;
    public bool hovered = false;

    private Vector3 offset;

    void Awake()
    {
        isMoving = false;
        hovered = false;
    }

    void OnEnable()
    {
        isMoving = false;
        hovered = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isMoving) return;

        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMoving) return;

        hovered = false;
    }

    private void Start()
    {
        isMoving = false;
    }

    void Update()
    {
        if (hovered && Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftControl))
            offset = transform.root.transform.position - new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);

        if (Input.GetMouseButton(0) && hovered && !Input.GetKey(KeyCode.LeftControl))
        {
            isMoving = true;
            transform.root.transform.position = Vector3.Lerp(transform.root.transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) + offset, 0.35f);
        }

        if (Input.GetMouseButton(0) && hovered)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
            {
                Instantiate(transform.root.gameObject, transform.root.transform.position + (Vector3.left * 6), Quaternion.identity);
            }
        }

        if (hovered && Input.GetMouseButtonUp(0))
            isMoving = false;
    }
}
