using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miro_Cam : MonoBehaviour
{
    // Start is called before the first frame update
    private bool insideMaze = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Maze"))
        {
            insideMaze = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.CompareTag("Maze"))
        {
            if(other.CompareTag("CATK"))
            {
                insideMaze = true;

            }
            else 
            {
                insideMaze = false;
            }
            
        }
    }

    public bool IsInsideMaze()
    {
        return insideMaze;
    }
}
