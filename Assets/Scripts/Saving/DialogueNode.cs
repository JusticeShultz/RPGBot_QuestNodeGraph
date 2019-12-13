using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNode : MonoBehaviour
{
    public ulong id = 0;

    public Node inputNode;
    public Node outputLootNode;
    public Node outputNode1;
    public Node outputNode2;
    public Node outputNode3;
    public InputField inputText;
    public InputField inputLinkText;

    private void Awake()
    {
        SaveStack.instance.savables.Add(gameObject);
    }

    private void OnDestroy()
    {
        for(int i = 0; i < SaveStack.instance.savables.Count; i++)
        {
            if(SaveStack.instance.savables[i] == gameObject)
            {
                SaveStack.instance.savables.Remove(SaveStack.instance.savables[i]);
            }
        }
    }
}