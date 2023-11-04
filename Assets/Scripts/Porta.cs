using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Transform[] pos;
    public float velocidade = 1.5f;

    void Update()
    {
        if (Botao.pisou == true || transform.position.x <= pos[1].position.x)
        {
            transform.Translate(Vector2.right * Time.deltaTime * velocidade);
        }
        if (Botao.pisou == false || transform.position.x >= pos[0].position.x)
        {
            transform.Translate(Vector2.left * Time.deltaTime * velocidade);
        }
    }
}
