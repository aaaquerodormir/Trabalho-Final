using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSegueJogador : MonoBehaviour
{
    public Transform jogador; // Refer�ncia ao jogador
    
    //public Light luz;

    //void Start()
    //{
    //    luz.enabled = false; // Inicialmente, desliga a luz
    //}

    void Update()
    {
        if (jogador != null)
        {
            // Atualiza a posi��o da luz para seguir o jogador
            transform.position = new Vector3(jogador.position.x, jogador.position.y, transform.position.z);
        }
        
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Maze")) // Verifica se o jogador entrou na �rea com a tag "Maze"
    //    {
    //        luz.enabled = true; // Liga a luz quando o jogador entra na �rea "Maze"
    //        Debug.Log("Luz ativada!");
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Maze")) // Verifica se o jogador saiu da �rea com a tag "Maze"
    //    {
    //        luz.enabled = false; // Desliga a luz quando o jogador sai da �rea "Maze"
    //    }
    //}

}
