using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoDano : MonoBehaviour
{
    public int maxHealth = 20; // Vida máxima do objeto
    private int currentHealth;
    
    public Animator animator;
    private bool isDead = false;
    public string bossTag = "Boss"; // Tag do boss na Unity

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
  
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifique se o objeto colidiu com o ataque do jogador
        if (collision.CompareTag("CATK"))
        {
            // Cause dano ao objeto
            TakeDamageFromPlayer();

            // Causa dano ao boss se o objeto for destruído
            if (currentHealth <= 0)
            {
                CauseDamageToBoss();
                animator.SetTrigger("DestroyTrigger");  
                isDead = true;
                StartCoroutine(DestroyAfterAnimation());

            }
        }
    }

    void TakeDamageFromPlayer()
    {
        // Coloque aqui a lógica para causar dano ao objeto
        currentHealth -= 5; // Exemplo de redução de 1 de vida

        // Verifique se o objeto ainda tem vida
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;

            StartCoroutine(DestroyAfterAnimation());
        }
    }

    void CauseDamageToBoss()
    {
        // Quando o objeto for destruído, encontre o boss e cause dano a ele
        GameObject boss = GameObject.FindWithTag(bossTag);

        if (boss != null)
        {
            // Verifique se o objeto possui um script de vida do boss
            BossLife bossLife = boss.GetComponent<BossLife>();
            if (bossLife != null)
            {
                bossLife.TakeDamage(50); // Exemplo de causar 10 de dano ao boss
            }
            else
            {
                Debug.LogWarning("Objeto de dano não encontrou o script BossLife no boss.");
            }
        }
        else
        {
            Debug.LogWarning("Objeto de dano não encontrou o boss na cena. Certifique-se de adicionar a tag 'Boss' ao seu boss.");
        }
    }

    IEnumerator DestroyAfterAnimation()
    {

        // Aguarde o término da animação de morte
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        // Causa dano ao boss após a animação
        

        // Destrua o objeto
        Destroy(gameObject);
    }
}
