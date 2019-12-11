using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Connector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static List<Connector> connectors = new List<Connector>();
    public static Connector connector;

    public Vector3 point2;
    public Vector3 point3temp;

    Transform point3 = null;
    public int vertexCount = 12;
    public bool hovered = false;
    public bool moving = false;

    LineRenderer lineRenderer;
    SpriteRenderer sprite;
    
    void Start()
    {
        connectors.Add(this);
        sprite = GetComponent<SpriteRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPositions(new Vector3[0]);
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && hovered && !moving && connector == null)
        {
            point3 = null;
            moving = true;
            connector = this;
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && moving)
            {
                for (int i = 0; i < connectors.Count; i++)
                {
                    if (sprite.bounds.Contains(connectors[i].transform.position))
                    {
                        point3 = connectors[i].transform;
                        break;
                    }
                }

                connector = null;
            }
            else
            {
                point3 = null;
                point3temp = transform.position;
            }
        }

        if (moving && connector == this)
        {
            point3temp = Vector3.Lerp(transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), 0.35f);
        }

        if (!point3)
        {
            var pointLista = new List<Vector3>();

            point2 = new Vector3((transform.position.x + point3temp.x) / 2, (transform.position.y + point3temp.y) / 2, 0) + (Vector3.left * 0.25f);

            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(transform.position, point2, ratio);
                var tangentLineVertex2 = Vector3.Lerp(point2, point3temp, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointLista.Add(bezierpoint);
            }

            lineRenderer.positionCount = pointLista.Count;
            lineRenderer.SetPositions(pointLista.ToArray());

            return;
        }
        
        var pointList = new List<Vector3>();

        point2 = new Vector3((transform.position.x + point3.position.x) / 2, (transform.position.y + point3.position.y) / 2, 0) + (Vector3.left * 0.25f);

        for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
        {
            var tangentLineVertex1 = Vector3.Lerp(transform.position, point2, ratio);
            var tangentLineVertex2 = Vector3.Lerp(point2, point3.position, ratio);
            var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
            pointList.Add(bezierpoint);
        }

        lineRenderer.positionCount = pointList.Count;
        lineRenderer.SetPositions(pointList.ToArray());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
}