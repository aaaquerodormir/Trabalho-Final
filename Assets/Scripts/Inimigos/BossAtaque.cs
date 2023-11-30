using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAtaque : MonoBehaviour
{
    // Start is called before the first frame update
    public float distanciaDoTiro;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;
    public Animator animator;

      private MiroHp playerHealth;

    // Tempo que o jogador está fora do campo de visão
    private float tempoForaDeVisao;

    // Tempo necessário para começar a rodar a animação após o jogador estar fora do campo de visão
    public float tempoParaAnimacao = 3f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<MiroHp>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer <= distanciaDoTiro && nextFireTime < Time.time && playerHealth.health > 0)
        {
            // Atualize o tempo fora de visão para zero se o jogador estiver dentro do campo de visão
            tempoForaDeVisao = 0;
            // Use a posição do inimigo como ponto de origem para a bala
            Instantiate(bullet, transform.position, Quaternion.identity);

            animator.SetBool("isShooting", true);
            animator.SetBool("BossRindo", false);
            nextFireTime = Time.time + fireRate;
        }
        else
        {
            animator.SetBool("isShooting", false);
            // Se o jogador estiver fora do campo de visão, atualize o tempo fora de visão
            if (tempoForaDeVisao <= tempoParaAnimacao)
            {
                tempoForaDeVisao += Time.deltaTime;
            }
            else
            {
                if(tempoForaDeVisao < tempoParaAnimacao + 1)
                {
                    animator.SetBool("BossRindo", true);
                }
                else
                {
                    animator.SetBool("BossRindo", false);
                }
                // Execute a animação após o tempo especificado
                
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, distanciaDoTiro);
    }

}
