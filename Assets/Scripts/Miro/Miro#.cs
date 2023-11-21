using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Miro : MonoBehaviour
{
    //Defines Padrão

    public Animator       anim;    // animator do personagem
    public float          speed;     // Velocidade do peronsagem
    private Rigidbody2D   rb; // fisica do player
    private Vector2       movPlayer;

    private bool _isAttack = false;

    public bool temColetavel;

    public static SpriteRenderer sprite;

    [SerializeField]
    string leveltoload;


    //Interação
    public static bool EstaInteragindo { get; set; }

    public GameObject mochila;
    public static bool Backpack;
    public static bool Rato;
    public static bool Bola;
    public static bool BingBong;
    public static bool Ball;
    public static bool Vara;
    public static bool CaixaLeite;


    float speedAtual;
    public float speedDash;

    public float reloadDash;
    bool InDash;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        temColetavel = false;
        Backpack = false;
        speedAtual = speed;
    }

    

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movPlayer * speedAtual * Time.fixedDeltaTime);
    }

    void Update()
    {
        if(speedAtual == speed)
        {
            movPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        

        anim.SetFloat("Lateral", movPlayer.x);           // aqui temos o controle do animator para cada lado  
        anim.SetFloat("Vertical", movPlayer.y);
        anim.SetFloat("Speed", movPlayer.magnitude);
        movPlayer.Normalize();

        if(Input.GetKeyDown(KeyCode.LeftShift) && movPlayer != Vector2.zero && InDash == false)
        {
            InDash = true;
            speedAtual = speedDash;
            Invoke("PosDash", 0.1f);
        }


        OnAttack();
        ChangeTimeLevel();


        if(Input.GetButtonDown("Interage"))
         {
             EstaInteragindo = true;

         }
         else
         {
             EstaInteragindo = false;
         }

        if (Input.GetButtonDown("Inventário"))
        {
            if (Backpack == false)
            {
                mochila.SetActive(true);
                Backpack = true;
            }
            else
            {
                mochila.SetActive(false);
                Backpack = false;
            }
        }

        if(_isAttack)
        {
            anim.SetFloat("Ataque", 2.1f);
        }
        if(!_isAttack) 
        {
            anim.SetFloat("Ataque", 1.9f);
        }
    }



    private void ChangeTimeLevel()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(EsperarSegundos(1f));
            
            
        }
        if (Input.GetButtonDown("Fire3"))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rato"))
        {
            Rato = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bola"))
        {
            Bola = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bing"))
        {
            BingBong = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("La"))
        {
            Ball = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Vara"))
        {
            Vara = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Milk"))
        {
            CaixaLeite = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator EsperarSegundos(float segundos)
    {
        
        yield return new WaitForSeconds(segundos);
        SceneManager.LoadScene(leveltoload);
        
    }

    void OnAttack()
    {
        if(Input.GetKeyDown(KeyCode.CapsLock))
        {
            _isAttack = true;
            speed = 0;

            movPlayer = Vector2.zero;

            float valorAtaque = anim.GetFloat("Lateral");

            if (valorAtaque > 0)
            {
                sprite.flipX = false; // Não inverte o sprite para a direita
            }
            else if (valorAtaque < 0)
            {
                sprite.flipX = true; // Inverte o sprite para a esquerda
            }
        }

        if(Input.GetKeyUp(KeyCode.CapsLock))
        {
            _isAttack = false;
            speed = 2;
            movPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            sprite.flipX = false;
        }
    }

    void PosDash()
    {
        speedAtual = speed;
        Invoke("FimDash", reloadDash);
    }

    void FimDash()
    {
        InDash = false;
    }
}



