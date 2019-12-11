using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteGameobject : MonoBehaviour
{
    public void Delete()
    {
        Draggable.isMoving = false;
        Destroy(gameObject);
    }
}
