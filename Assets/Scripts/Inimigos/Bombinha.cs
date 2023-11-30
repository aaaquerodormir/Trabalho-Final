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



    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


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
            Vector3 deltaPos = player.position - transform.position;
            movementDirection = new Vector2(deltaPos.x, deltaPos.y).normalized;

            float angle = Vector2.SignedAngle(Vector2.up, movementDirection);
            string animationName = GetAnimationName(movementDirection);
            Debug.Log(animationName);
            //animator.CrossFade(animationName, 0);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            animator.SetFloat("DirectionX", movementDirection.x);
            animator.SetFloat("DirectionY", movementDirection.y);
        }
    }
    string GetAnimationName(Vector2 normalizedDirection)
    {
        if (normalizedDirection.magnitude == 0) return "Raiva_Idle";
        else if (Mathf.Abs(normalizedDirection.x) >= Mathf.Abs(normalizedDirection.y))
        {
            if (normalizedDirection.x > 0) return "Raiva_Direita";
            else return "Raiva_Esquerda";
        }
        else
        {
            if (normalizedDirection.y > 0) return "Raiva_Cima";
            return "Raiva_Baixo";
        }
    }
    IEnumerator AttackTimer()
    {
        
        animator.SetTrigger("AttackCharge");
        audioManager.PlaySFX(audioManager.bombinha);
        yield return new WaitForSeconds(attackDelay);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        animator.SetTrigger("AttackRelease");
        yield return new WaitForSeconds(1.33f);
        if (distanceToPlayer < attackRadius)
        {
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
