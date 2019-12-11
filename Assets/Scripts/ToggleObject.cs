using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    public bool toggle = false;
    public GameObject target;

    public void Toggle()
    {
        toggle = !toggle;
        target.SetActive(toggle);
    }

    public void Toggle(bool _toggle)
    {
        toggle = _toggle;
        target.SetActive(toggle);
    }
}
