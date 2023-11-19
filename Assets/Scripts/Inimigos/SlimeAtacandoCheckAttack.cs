using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.U2D;

public class SlimeAtacandoCheckAttack : MonoBehaviour
{
    public static bool checkAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            checkAttack = true;
        }
    }
}


