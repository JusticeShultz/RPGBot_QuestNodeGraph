using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPNode : MonoBehaviour
{
    public Node inputNode;
    public Dropdown type;
    public InputField inputMax;
    public InputField inputMin;

    private void Awake()
    {
        SaveStack.instance.savables.Add(gameObject);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < SaveStack.instance.savables.Count; i++)
        {
            if (SaveStack.instance.savables[i] == gameObject)
            {
                SaveStack.instance.savables.Remove(SaveStack.instance.savables[i]);
            }
        }
    }
}
