using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ID : MonoBehaviour
{
    public ulong iD;

    private void Awake()
    {
        iD = SaveStack.GenerateID();
    }
}