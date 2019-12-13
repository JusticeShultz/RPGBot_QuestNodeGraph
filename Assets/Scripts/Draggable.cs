using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static bool isMoving = false;

    public GameObject hoveredTarget;
    public bool hovered = false;

    private bool dragging = false;
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
        if (hoveredTarget != null) return;

        hoveredTarget = gameObject;
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;

        if (dragging) return;

        hoveredTarget = null;
    }

    private void Start()
    {
        isMoving = false;
    }

    void Update()
    {
        if (dragging)
        {
            isMoving = true;
            transform.root.transform.position = Vector3.Lerp(transform.root.transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0) + offset, 0.35f);
        }
        
        if (hovered && hoveredTarget == gameObject && Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftControl))
            dragging = true;

        if (!Input.GetMouseButton(0))
        {
            offset = transform.root.transform.position - new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
            dragging = false;
            
            if(!hovered)
                hoveredTarget = null;
        }

        if (hovered)
        {
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
            {
                ID id = Instantiate(transform.root.gameObject, transform.root.transform.position + (Vector3.right * 4), Quaternion.identity).GetComponent<ID>();
                id.iD = SaveStack.GenerateID();
            }
        }

        if (Input.GetMouseButtonUp(0))
            isMoving = false;
    }
}
