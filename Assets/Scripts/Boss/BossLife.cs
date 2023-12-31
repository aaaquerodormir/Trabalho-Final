using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossLife : MonoBehaviour
{
    public int maxHealth = 80;
    private int currentHealth;
    public Image healthBar;

    public Animator bossAnimator;
    public Animator healAnimator; // Adicione um Animator para a anima��o de cura

    private bool isHealing = false; // Flag para verificar se o boss est� se curando
    private bool hasHealed = false;
    private int healAmount = 40; // Ajuste a quantidade de cura conforme necess�rio
    private int healThreshold = 40; // Ajuste o limite de vida para ativar a cura

    public GameObject itemToDrop;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        // Se a vida atual estiver abaixo do limiar de cura e o boss n�o estiver se curando
        if (currentHealth < healThreshold && !isHealing && !hasHealed)
        {
            StartHealing();
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            healthBar.fillAmount = Mathf.Clamp(currentHealth / (float)maxHealth, 0, 1);

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        if (bossAnimator != null)
        {
            bossAnimator.SetTrigger("Die");
            Invoke("DestroyBoss", 1.5f);

            DropItem();
        }
    }

    void DestroyBoss()
    {
        Destroy(gameObject);
    }

    void StartHealing()
    {
        if (!isHealing)
        {
            isHealing = true;

            // Adicione a anima��o de cura
            if (healAnimator != null)
            {
                healAnimator.SetBool("Heal", true); // "Heal" � o nome do booleano configurado na sua anima��o de cura
            }

            // Complete a cura
            currentHealth += healAmount;
            currentHealth = Mathf.Min(currentHealth, maxHealth);
            healthBar.fillAmount = Mathf.Clamp(currentHealth / (float)maxHealth, 0, 1);

            hasHealed = true;

            // Chame o m�todo para finalizar a cura ap�s um per�odo (ajuste conforme necess�rio)
            Invoke("FinishHealing", 1.1f);
        }
    }

    void FinishHealing()
    {
        // Adicione qualquer l�gica adicional necess�ria ao finalizar a cura
        isHealing = false;
        healAnimator.SetBool("Heal", false);
    }

    void DropItem()
    {
        // Instantiate() cria uma c�pia do item para dropar
        if (itemToDrop != null)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
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
