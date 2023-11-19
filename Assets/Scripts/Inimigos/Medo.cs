using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medo : MonoBehaviour
{
    [SerializeField]
    private float raioVisao;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, raioVisao);
    }
}
