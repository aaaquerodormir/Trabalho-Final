using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int maxHealth = 50;
    private int currentHealth;

    public Animator bossAnimator;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Verifique se o boss ainda tem vida
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (bossAnimator != null)
        {
            bossAnimator.SetTrigger("Die"); // "Die" é o nome do gatilho configurado na sua animação
        }
    }
    public void DestroyBoss()
    {
        Destroy(gameObject);
    }

}
