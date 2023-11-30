using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class InimigoSeguePlayer : MonoBehaviour
{
    public float speed;
    public float campoDeVisao;
    public float distanciaTiro;
    public float fireRate = 1f;
    private float nextFireTime;
    public GameObject bullet;
    public GameObject bulletParent;
    private Transform player;

    // barra de vida
    public Transform healthBar;
    public GameObject healthBarObject;

    private Vector3 healthBarScale;
    private float healthPercent;
    public float health;

    public int damage;
    private bool isDead = false;
    private Animator animator;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

        void Start()
    {
        audioManager.PlaySFX(audioManager.tristezaid);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthBarScale = healthBar.localScale;
        healthPercent = healthBarScale.x / health;
        damage = 5;
        animator = GetComponent<Animator>();
    }

    void UpdateHealthBar()
    {
        healthBarScale.x = healthPercent * health;
        healthBar.localScale = healthBarScale;
    }

    
    void Update()
    {

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < campoDeVisao && distanceFromPlayer > distanciaTiro)
        {
           
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
            
        }
        else if (distanceFromPlayer <= distanciaTiro && nextFireTime < Time.time)
        {
            audioManager.PlaySFX(audioManager.tristezaatk);

            // Use a posição do inimigo como ponto de origem para a bala
            Instantiate(bullet, transform.position, Quaternion.identity);

            animator.SetBool("isShooting", true);

            animator.SetBool("isTakingDamage", false);

            nextFireTime = Time.time + fireRate;
        }

        if (health <= 0 && !isDead)
        {
            // Ative a variável de animação de morte
            animator.SetBool("isDead", true);
            isDead = true;

            // Aguarde o término da animação de morte antes de destruir o objeto
            StartCoroutine(DestroyAfterAnimation());
        }


        IEnumerator DestroyAfterAnimation()
        {
            // Aguarde o término da animação de morte
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            // Destrua o objeto
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, campoDeVisao);
        Gizmos.DrawWireSphere(transform.position, distanciaTiro);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CATK"))
        {
            health -= damage;
            UpdateHealthBar();

            animator.SetBool("isTakingDamage", true);

            animator.SetBool("isShooting", false);

        }
    }

    
}
