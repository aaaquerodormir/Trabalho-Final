using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeioCirculo : MonoBehaviour
{
    public float raio = 2f;
    public int segmentos = 20;
    public float direcaoInicialEmGraus = 0f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        // Calcular os pontos ao redor do círculo
        float anguloPorSegmento = 180f / segmentos;
        float anguloInicialEmRadianos = Mathf.Deg2Rad * direcaoInicialEmGraus;
        Vector3 pontoAnterior = new Vector3(Mathf.Sin(anguloInicialEmRadianos) * raio, Mathf.Cos(anguloInicialEmRadianos) * raio, 0);

        for (int i = 0; i <= segmentos; i++)
        {
            float anguloEmRadianos = anguloInicialEmRadianos + Mathf.Deg2Rad * (i * anguloPorSegmento);
            float x = Mathf.Sin(anguloEmRadianos) * raio;
            float y = Mathf.Cos(anguloEmRadianos) * raio;

            Vector3 pontoAtual = new Vector3(x, y, 0);

            if (i > 0)
            {
                Gizmos.DrawLine(transform.position + pontoAnterior, transform.position + pontoAtual);
            }

            pontoAnterior = pontoAtual;
        }
    }
}
