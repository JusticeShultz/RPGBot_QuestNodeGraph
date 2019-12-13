using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveryDeityNode : MonoBehaviour
{
    public Node inputNode;
    public Node outputNode1;
    public Node outputNode2;
    public Node outputNode3;
    public Node outputNode4;
    public Node outputNode5;
    public Node outputNode6;
    public Node outputNode7;
    public Node outputNode8;
    
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
