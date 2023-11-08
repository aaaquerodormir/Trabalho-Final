using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinhos : MonoBehaviour
{
    public Animator espinhoAnimator;
    private bool levantado = false;
    private float timer = 0f;
    private float duracaoLevantado = 3f;
    private float duracaoAbaixado = 3f;
    
    
    void Update()
    {
        timer += Time.deltaTime;

        if (levantado && timer >= duracaoLevantado)
        {
            levantado = false;
            espinhoAnimator.SetBool("Levantado", false);
            timer = 0f;
        }
        else if (!levantado && timer >= duracaoAbaixado)
        {
            levantado = true;
            espinhoAnimator.SetBool("Levantado", true);
            timer = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && levantado)
        {
            MiroHp playerHealth = other.gameObject.GetComponent<MiroHp>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(2);
            }
        }
       
    }

   
}
