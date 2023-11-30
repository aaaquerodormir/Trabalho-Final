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


    AudioManager audioManager;


    private void Awake()
    {
        AtualizarAnimatorDeAcordoComCena();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
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

        if(Input.GetKeyDown(KeyCode.C) && movPlayer != Vector2.zero && InDash == false)
        {
            audioManager.PlaySFX(audioManager.dash);
            InDash = true;
            speedAtual = speedDash;
            Invoke("PosDash", 0.1f);
        }


        OnAttack();
        ChangeTimeLevel();


        if(Input.GetButtonDown("Interage"))
         {

            audioManager.PlaySFX(audioManager.interacao);
            EstaInteragindo = true;

         }
         else
         {
             EstaInteragindo = false;
         }

        if (Input.GetButtonDown("Inventário"))
        {
            audioManager.PlaySFX(audioManager.inventario);

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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(EsperarSegundos(1f));
            audioManager.PlaySFX(audioManager.viagem);

        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerPrefs.DeleteAll();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rato"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
            Rato = true;
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.CompareTag("Bola"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
            Bola = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Bing"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
            BingBong = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("La"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
            Ball = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Vara"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
            Vara = true;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Milk"))
        {
            audioManager.PlaySFX(audioManager.coletavel);
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            audioManager.PlaySFX(audioManager.ataque);
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

        if(Input.GetKeyUp(KeyCode.Space))
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

    void AtualizarAnimatorDeAcordoComCena()
    {
        
        string nomeCenaAtual = SceneManager.GetActiveScene().name;

        
        if (nomeCenaAtual == "Floresta")
        {
            
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/Miro1");
        }
        else if (nomeCenaAtual == "Floresta--")
        {
            
            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/DeadMiro1");
        }

        if (nomeCenaAtual == "Labirinto")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/Miro1");
        }
        else if (nomeCenaAtual == "Labirinto--")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/DeadMiro1");
        }

        if (nomeCenaAtual == "Casa")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/Miro1");
        }
        else if (nomeCenaAtual == "Casa--")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/DeadMiro1");
        }

        if (nomeCenaAtual == "Inside")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/Miro1");
        }
        else if (nomeCenaAtual == "Inside--")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/DeadMiro1");
        }

        if (nomeCenaAtual == "Deserto")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/Miro1");
        }
        else if (nomeCenaAtual == "Deserto--")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/DeadMiro1");
        }
        if (nomeCenaAtual == "Plataform")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/Miro1");
        }
        else if (nomeCenaAtual == "Plataform--")
        {

            anim.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimatorControllers/DeadMiro1");
        }

    }
}



