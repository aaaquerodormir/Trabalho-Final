using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    private int maxHealth = 40;
    private int currentHealth;
    public Image healthBar;


    public Animator bossAnimator;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.fillAmount = Mathf.Clamp(currentHealth / (float)maxHealth, 0, 1);
        Debug.Log("Health Bar Fill Amount: " + healthBar.fillAmount); // Adicione este log
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

        Destroy(gameObject);
    }


    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
        healthBar.fillAmount = 1f;
    }
    //public void DestroyBoss()
    //{
    //    Destroy(gameObject);
    //}

}
