using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueNode : MonoBehaviour
{
    public Node inputNode;
    public Node outputLootNode;
    public Node outputNode1;
    public Node outputNode2;
    public Node outputNode3;
    public InputField inputText;

    private void Awake()
    {
        print("Dialogue node created");
        SaveStack.savables.Add(this);
    }

    private void OnDestroy()
    {
        for(int i = 0; i < SaveStack.savables.Count; i++)
        {
            if(SaveStack.savables[i] == this)
            {
                SaveStack.savables.Remove(SaveStack.savables[i]);
            }
        }
    }
}