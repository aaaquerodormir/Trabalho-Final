using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl2 : MonoBehaviour
{
    [SerializeField]
    private Transform[] fotos;

    [SerializeField]
    private GameObject venceu;

    public static bool vitoria;

    void Start()
    {
        venceu.SetActive(false);
        vitoria = false;
    }

    void Update()
    {
        if (fotos[0].rotation.z == 0 &&
            fotos[1].rotation.z == 0 &&
            fotos[2].rotation.z == 0 &&
            fotos[3].rotation.z == 0 &&
            fotos[4].rotation.z == 0 &&
            fotos[5].rotation.z == 0 &&
            fotos[6].rotation.z == 0 &&
            fotos[7].rotation.z == 0 &&
            fotos[8].rotation.z == 0 &&
            fotos[9].rotation.z == 0 &&
            fotos[10].rotation.z == 0 &&
            fotos[11].rotation.z == 0 &&
            fotos[12].rotation.z == 0 &&
            fotos[13].rotation.z == 0 &&
            fotos[14].rotation.z == 0 &&
            fotos[15].rotation.z == 0)
        {
            vitoria = true;
            venceu.SetActive(true);
        }

    }
}

