using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    public ulong iD;

    private void Awake()
    {
        if (SaveStack.instance != null)
            iD = SaveStack.GenerateID();

        if (MonsterSaveStack.instance != null)
            iD = MonsterSaveStack.GenerateID();
    }
}