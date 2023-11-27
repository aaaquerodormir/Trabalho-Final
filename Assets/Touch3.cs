using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch3 : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!TouchControl3.alanis)
        {
            transform.Rotate(0f, 0f, 90f);
        }

    }
}
