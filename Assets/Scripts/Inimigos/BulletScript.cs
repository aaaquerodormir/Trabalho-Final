using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");

        //direção do tiro
        Vector2 moveDir = target.transform.position - transform.position;

        //velocidade do tiro
        bulletRB.velocity = moveDir.normalized * speed;

        // Calcula o ângulo entre a direção do tiro e o eixo X
        float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;

        // Rotaciona o sprite do tiro na direção do ângulo calculado
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Destroy(this.gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MiroHp playerHealth = other.gameObject.GetComponent<MiroHp>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(2);
            }
            Destroy(this.gameObject);
        }
        
    }
}
