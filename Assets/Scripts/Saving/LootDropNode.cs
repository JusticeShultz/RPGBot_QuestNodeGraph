using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LootDropNode : MonoBehaviour
{
    public Node inputNode;
    public Dropdown type;
    public Dropdown rarityMax;
    public Dropdown rarityMin;

    private void Awake()
    {
        SaveStack.savables.Add(this);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < SaveStack.savables.Count; i++)
        {
            if (SaveStack.savables[i] == this)
            {
                SaveStack.savables.Remove(SaveStack.savables[i]);
            }
        }
    }
}
