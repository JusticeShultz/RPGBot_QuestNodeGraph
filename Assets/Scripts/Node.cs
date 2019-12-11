using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Node : MonoBehaviour
{
    public static bool NodeSetter = false;

    public static GameObject ToSet = null;

    public int vertexCount = 12;

    public GameObject link = null;

    public bool isInput = false;

    Vector3 point2;
    Vector3 point3;

    [HideInInspector] public LineRenderer lRenderer;

    void Start()
    {
        lRenderer = GetComponent<LineRenderer>();
        NodeSetter = false;
        ToSet = null;
    }

    void Update()
    {
        if(!link)
            lRenderer.SetPositions(new Vector3[0]);

        point3 = Vector3.Lerp(transform.position, new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0), 0.35f);
        point2 = new Vector3((transform.position.x + point3.x) / 2, (transform.position.y + point3.y) / 2, 0) + (Vector3.left * 0.25f);

        if (link != null)
        {
            var pointList = new List<Vector3>();

            point2 = new Vector3((transform.position.x + link.transform.position.x) / 2, (transform.position.y + link.transform.position.y) / 2, 0) + (Vector3.left * 0.25f);

            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(transform.position, point2, ratio);
                var tangentLineVertex2 = Vector3.Lerp(point2, link.transform.position, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierpoint);
            }

            lRenderer.positionCount = pointList.Count;
            lRenderer.SetPositions(pointList.ToArray());

            return;
        }
        else if (ToSet == gameObject && NodeSetter)
        {
            var pointList = new List<Vector3>();

            for (float ratio = 0; ratio <= 1; ratio += 1.0f / vertexCount)
            {
                var tangentLineVertex1 = Vector3.Lerp(transform.position, point2, ratio);
                var tangentLineVertex2 = Vector3.Lerp(point2, point3, ratio);
                var bezierpoint = Vector3.Lerp(tangentLineVertex1, tangentLineVertex2, ratio);
                pointList.Add(bezierpoint);
            }

            lRenderer.positionCount = pointList.Count;
            lRenderer.SetPositions(pointList.ToArray());
        }
        else lRenderer.positionCount = 0;
    }

    public void Pressed()
    {
        if(NodeSetter)
        {
            if (ToSet != gameObject)
            {
                if (!isInput)
                {
                    return;
                }
                else
                {
                    ToSet.GetComponent<Node>().link = gameObject;
                    NodeSetter = false;
                    ToSet = null;
                }
            }
            else
            {
                NodeSetter = false;
                ToSet = null;
            }
        }
        else
        {
            if (isInput) return;

            NodeSetter = true;
            ToSet = gameObject;
            link = null;
        }

        lRenderer.positionCount = 0;
    }
}
