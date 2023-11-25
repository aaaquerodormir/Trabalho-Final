using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombinha : MonoBehaviour
{
    public float speed = 3f; // Velocidade de movimento do inimigo
    public float visionRadius = 5f; // Raio de visão do inimigo
    public float attackRadius = 1f; // Raio de ataque do inimigo
    public float attackDelay = 3f; // Tempo de atraso antes de ativar o ataque
    public float damage = 7f; // Quantidade de dano a ser causada

    public Animator animator;
    private Vector2 movementDirection = Vector2.zero;

    private Transform player; // Referência ao transform do jogador
    private bool hasAttacked = false;

    [SerializeField]
    private float distanciaMinima;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Encontrar o jogador pela tag
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasAttacked)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            // Verificar se o jogador está dentro do campo de visão
            if (distanceToPlayer < visionRadius && distanceToPlayer > distanciaMinima)
            {
                if (movementDirection != Vector2.zero)
                {
                    // Se o jogador estiver se movendo, ativar o parâmetro "IsMoving"
                    animator.SetBool("IsMoving", true);
                    Debug.Log("IsMoving setado como true");
                }
                else
                {
                    // Se o jogador não estiver se movendo, desativar o parâmetro "IsMoving"
                    animator.SetBool("IsMoving", false);
                    Debug.Log("IsMoving setado como false");
                }

                // Verificar se o jogador está dentro do raio de ataque
                if (distanceToPlayer < attackRadius)
                {
                    StartCoroutine(AttackTimer());
                    MoveTowardsPlayer(distanceToPlayer);
                }
                else
                {
                    // Se o jogador estiver dentro do campo de visão, perseguir o jogador
                    MoveTowardsPlayer(distanceToPlayer);
                }
            }
        }
    }

    void MoveTowardsPlayer(float distanceToPlayer)
    {
        movementDirection = (player.position - transform.position).normalized;

        if (distanceToPlayer > attackRadius)
        {
            // Configuração do Blend Tree
            float angle = Vector2.SignedAngle(Vector2.up, movementDirection);
            animator.SetFloat("Direction", angle / 180f); // Normalizar o ângulo entre -1 e 1
            animator.SetFloat("Speed", speed / distanceToPlayer);
        }

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    IEnumerator AttackTimer()
    {
        // Ativar animação de carga do ataque
        animator.SetTrigger("AttackCharge");

        // Aguardar o tempo de atraso antes de ativar o ataque
        yield return new WaitForSeconds(attackDelay);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Verificar se o jogador ainda está dentro do raio de ataque antes de atacar
        if (distanceToPlayer < attackRadius)
        {
            // Ativar animação de liberação do ataque
            animator.SetTrigger("AttackRelease");

            // Ativar o colisor ou a lógica de dano aqui
            DealDamage();
        }

        // Marcador de que o inimigo já atacou, para evitar ataques repetidos
        hasAttacked = true;

        // Destruir o inimigo após o ataque
        Destroy(gameObject);
    }

    void DealDamage()
    {
        MiroHp miroHp = player.GetComponent<MiroHp>();
        miroHp.TakeDamage(7);
    }

    void OnDrawGizmos()
    {
        // Visualizar o raio de visão
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        // Visualizar o raio de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaMinima);
    }

    void OnDrawGizmosSelected()
    {
        // Visualizar o raio de ataque quando o objeto estiver selecionado
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
