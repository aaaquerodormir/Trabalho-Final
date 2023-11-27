using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch2 : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!TouchControl2.vitoria)
        {
            transform.Rotate(0f, 0f, 90f);
        }

    }
}
