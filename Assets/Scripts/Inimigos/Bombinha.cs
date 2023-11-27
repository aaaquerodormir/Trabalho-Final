using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombinha : MonoBehaviour
{
    public float speed = 3f;
    public float visionRadius = 5f;
    public float attackRadius = 1f;
    public float attackDelay = 3f;
    public float damage = 7f;

    public Animator animator;
    private Vector2 movementDirection = Vector2.zero;

    private Transform player;
    private bool hasAttacked = false;

    [SerializeField]
    private float distanciaMinima;

    private bool hasEnteredAttackArea = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!hasAttacked)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer < visionRadius && distanceToPlayer > distanciaMinima)
            {
                if (movementDirection != Vector2.zero)
                {
                    animator.SetBool("IsMoving", true);
                    Debug.Log("IsMoving setado como true");
                }
                else
                {
                    animator.SetBool("IsMoving", false);
                    Debug.Log("IsMoving setado como false");
                }

                if (distanceToPlayer < attackRadius)
                {
                    StartCoroutine(AttackTimer());
                    MoveTowardsPlayer(distanceToPlayer);
                }
                else
                {
                    MoveTowardsPlayer(distanceToPlayer);
                }
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }

    void MoveTowardsPlayer(float distanceToPlayer)
    {
        if (!hasEnteredAttackArea && distanceToPlayer < attackRadius)
        {
            float savedSpeed = speed;
            Vector2 savedMovementDirection = movementDirection;

            // Se o jogador estiver dentro do raio de ataque pela primeira vez, ativar movimentação carregada
            animator.SetBool("IsChargedMovement", true);
            animator.SetBool("IsNormalMovement", false);

            // Restaura a direção e a velocidade para a movimentação normal
            movementDirection = savedMovementDirection;
            speed = savedSpeed;

            hasEnteredAttackArea = true;

            // Se quiser manter a lógica de ataque, inclua aqui a chamada para a lógica de ataque
            StartCoroutine(AttackTimer());
        }
        else
        {
            // Caso contrário, continuar com a movimentação normal
            movementDirection = (player.position - transform.position).normalized;

            float angle = Vector2.SignedAngle(Vector2.up, movementDirection);

            if (angle < 0)
            {
                angle += 360f;
            }

            string animationName = GetAnimationName(angle);

            animator.CrossFade(animationName, 0);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            animator.SetFloat("Direction", angle / 180f);
            animator.SetFloat("Speed", speed / distanceToPlayer);
        }
    }
    string GetAnimationName(float angle)
    {
        Debug.Log("Angle: " + angle); // Adicione esta linha para verificar o ângulo

        if (angle >= 135f & angle < 45f)
        {
            return "Raiva_Cima";
        }

        if (angle >= 225f & angle < 135f)
        {
            return "Raiva_Esquerda";
        }

        if (angle >= 315f & angle < 225f)
        {
            return "Raiva_Baixo";
        }

        if (angle >= 45f & angle < 315f)
        {
            return "Raiva_Direita";
        }
        return "Raiva_Idle";
    }

    IEnumerator AttackTimer()
    {
        animator.SetTrigger("AttackCharge");
        yield return new WaitForSeconds(attackDelay);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRadius)
        {
            animator.SetTrigger("AttackRelease");
            DealDamage();
        }

        hasAttacked = true;
        Destroy(gameObject);
    }

    void DealDamage()
    {
        MiroHp miroHp = player.GetComponent<MiroHp>();
        miroHp.TakeDamage(7);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, distanciaMinima);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

}
