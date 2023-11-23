using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDano : MonoBehaviour
{
    public int maxHealth = 20; // Vida m�xima do objeto
    private int currentHealth;

    

    public string bossTag = "Boss"; // Tag do boss na Unity

    void Start()
    {
        currentHealth = maxHealth;
  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifique se o objeto colidiu com o ataque do jogador
        if (collision.CompareTag("CATK"))
        {
            // Cause dano ao objeto
            TakeDamageFromPlayer();

            // Causa dano ao boss se o objeto for destru�do
            if (currentHealth <= 0)
            {
                CauseDamageToBoss();
            }
        }
    }

    void TakeDamageFromPlayer()
    {
        // Coloque aqui a l�gica para causar dano ao objeto
        currentHealth -= 5; // Exemplo de redu��o de 1 de vida

        // Atualize a barra de vida do objeto
        UpdateHealthBar();

        // Verifique se o objeto ainda tem vida
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void CauseDamageToBoss()
    {
        // Quando o objeto for destru�do, encontre o boss e cause dano a ele
        GameObject boss = GameObject.FindWithTag(bossTag);

        if (boss != null)
        {
            // Verifique se o objeto possui um script de vida do boss
            BossLife bossLife = boss.GetComponent<BossLife>();
            if (bossLife != null)
            {
                bossLife.TakeDamage(10); // Exemplo de causar 10 de dano ao boss
            }
            else
            {
                Debug.LogWarning("Objeto de dano n�o encontrou o script BossLife no boss.");
            }
        }
        else
        {
            Debug.LogWarning("Objeto de dano n�o encontrou o boss na cena. Certifique-se de adicionar a tag 'Boss' ao seu boss.");
        }
    }

    void Die()
    {
        // Adicione aqui qualquer l�gica adicional que desejar quando o objeto morrer
        Debug.Log("Objeto morreu!");
        Destroy(gameObject);
    }

    void UpdateHealthBar()
    {
        // Adicione aqui qualquer l�gica para atualizar a barra de vida do objeto
        // Por exemplo, voc� pode querer usar uma barra de vida UI ou outro m�todo de visualiza��o
    }

}
