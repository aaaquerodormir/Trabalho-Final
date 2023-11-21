using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Damage : MonoBehaviour
{
    //public PlayerHealth pHealth;
    public float damage;
    public float restartDelay = 1.0f; // Tempo de atraso em segundos
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(Blink());
            MiroHp playerHealth = other.gameObject.GetComponent<MiroHp>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                if (playerHealth.health <= 0)
                {
                    Invoke("RestartScene", restartDelay); // Chama a função de reiniciar após o atraso
                }
            }
        }
    }

    void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
