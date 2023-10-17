using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miro : MonoBehaviour
{
    public Animator       anim;    // animator do personagem
    public float          speed;     // Velocidade do peronsagem
    private Rigidbody2D   rb; // fisica do player
    private Vector2       movPlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }



    void Update()
    {

        movPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        anim.SetFloat("Lateral", movPlayer.x);           // aqui temos o controle do animator para cada lado  
        anim.SetFloat("Vertical", movPlayer.y);
        anim.SetFloat("Speed", movPlayer.magnitude);
        movPlayer.Normalize();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movPlayer * speed * Time.fixedDeltaTime);
    }



}
