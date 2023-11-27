using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Casa : MonoBehaviour
{
    
    static Animator animator;

    
    

    private void Start()
    {
        
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on Casa GameObject.");
        }
    }

    public static void Abriu()
    {
        // Verifica se o Animator está configurado
        if (animator != null)
        {
            // Defina o parâmetro "Aberta" para true para acionar a animação de abertura
            animator.SetBool("abriu", true); 
            
        }
        else
        {
            Debug.LogError("Animator not initialized on Casa script.");
        }
    }
}
