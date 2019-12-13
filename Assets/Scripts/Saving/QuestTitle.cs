using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestTitle : MonoBehaviour
{
    public InputField inputField;
    public Node outputNode;

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
