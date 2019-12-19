using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaTitle : MonoBehaviour
{
    public ulong id = 0;

    public InputField input_Name;

    private void Awake()
    {
        MonsterSaveStack.instance.savables.Add(gameObject);
    }

    private void OnDestroy()
    {
        for (int i = 0; i < MonsterSaveStack.instance.savables.Count; i++)
        {
            if (MonsterSaveStack.instance.savables[i] == gameObject)
            {
                MonsterSaveStack.instance.savables.Remove(MonsterSaveStack.instance.savables[i]);
            }
        }
    }
}
