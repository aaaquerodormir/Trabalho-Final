using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Miro : MonoBehaviour
{
    public Animator anim;    // animator do personagem
    public float speed;     // Velocidade do peronsagem
    private Rigidbody2D rb; // fisica do player


    void Start()
    {
        

    }



    void Update()
    {


        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f); // colocando os inputs para movimentar o personagem
        movement.Normalize();


        anim.SetFloat("Lateral", movement.x);           // aqui temos o controle do animator para cada lado  
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);

        transform.position = transform.position + movement * speed * Time.deltaTime; // realizamos a movimentação do personagem 
        
        
    }
}
