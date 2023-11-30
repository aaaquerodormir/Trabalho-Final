using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    
    public int healingAmount = 8; // Ajuste a quantidade de cura conforme necessário
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player")) // Verifique se o objeto que colidiu é o jogador
            {
                audioManager.PlaySFX(audioManager.sache);
                MiroHp playerHealth = other.GetComponent<MiroHp>();
                if (playerHealth != null)
                {
                    playerHealth.Heal(healingAmount); // Chame o método de cura do jogador
                    Destroy(gameObject); // Destrua a poção após o uso  
                }
            }
        }
    }
