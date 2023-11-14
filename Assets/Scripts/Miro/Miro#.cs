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
         





    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        temColetavel = false;
        Backpack = false;
    }

    

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movPlayer * speed * Time.fixedDeltaTime);
    }

    void Update()
    {

        movPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        anim.SetFloat("Lateral", movPlayer.x);           // aqui temos o controle do animator para cada lado  
        anim.SetFloat("Vertical", movPlayer.y);
        anim.SetFloat("Speed", movPlayer.magnitude);
        movPlayer.Normalize();

        ChangeTimeLevel();


        /* if(Input.GetButtonDown("Interage"))
         {
             EstaInteragindo = true;

         }
         else
         {
             EstaInteragindo = false;
         } */

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



    }



    private void ChangeTimeLevel()
    {
        if (Input.GetButtonDown("Fire2"))
        {

            SceneManager.LoadScene(leveltoload);
            
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
}



