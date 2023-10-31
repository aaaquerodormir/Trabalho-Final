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

    public static SpriteRenderer sprite;
    [SerializeField]
    string leveltoload;


    //Interação
    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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

    

        

    }

   

