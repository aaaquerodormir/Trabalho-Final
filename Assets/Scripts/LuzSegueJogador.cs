using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzSegueJogador : MonoBehaviour
{
    public Transform jogador; // Referência ao jogador
    
    //public Light luz;

    //void Start()
    //{
    //    luz.enabled = false; // Inicialmente, desliga a luz
    //}

    void Update()
    {
        if (jogador != null)
        {
            // Atualiza a posição da luz para seguir o jogador
            transform.position = new Vector3(jogador.position.x, jogador.position.y, transform.position.z);
        }
        
    }
    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Maze")) // Verifica se o jogador entrou na área com a tag "Maze"
    //    {
    //        luz.enabled = true; // Liga a luz quando o jogador entra na área "Maze"
    //        Debug.Log("Luz ativada!");
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Maze")) // Verifica se o jogador saiu da área com a tag "Maze"
    //    {
    //        luz.enabled = false; // Desliga a luz quando o jogador sai da área "Maze"
    //    }
    //}

}
