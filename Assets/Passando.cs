using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passando : MonoBehaviour
{
    public GameObject porta;


    void Update()
    {
        if(TouchControl.youWin && TouchControl2.vitoria && TouchControl3.alanis)
        {
            Destroy(porta);
            Debug.Log("DeuCerto");
        }
    }
}
