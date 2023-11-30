using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl3 : MonoBehaviour
{
    [SerializeField]
    private Transform[] imagens;

    [SerializeField]
    private GameObject cantou;

    public static bool alanis;

    

    void Start()
    {
        cantou.SetActive(false);
        alanis = false;
    }

    void Update()
    {
        if (imagens[0].rotation.z == 0 &&
            imagens[1].rotation.z == 0 &&
            imagens[2].rotation.z == 0 &&
            imagens[3].rotation.z == 0 &&
            imagens[4].rotation.z == 0 &&
            imagens[5].rotation.z == 0 &&
            imagens[6].rotation.z == 0 &&
            imagens[7].rotation.z == 0 &&
            imagens[8].rotation.z == 0 &&
            imagens[9].rotation.z == 0 &&
            imagens[10].rotation.z == 0 &&
            imagens[11].rotation.z == 0 &&
            imagens[12].rotation.z == 0 &&
            imagens[13].rotation.z == 0 &&
            imagens[14].rotation.z == 0 &&
            imagens[15].rotation.z == 0 &&
            imagens[16].rotation.z == 0 &&
            imagens[17].rotation.z == 0 &&
            imagens[18].rotation.z == 0 &&
            imagens[19].rotation.z == 0 &&
            imagens[20].rotation.z == 0 &&
            imagens[21].rotation.z == 0 &&
            imagens[22].rotation.z == 0 &&
            imagens[23].rotation.z == 0 &&
            imagens[24].rotation.z == 0 &&
            imagens[25].rotation.z == 0 &&
            imagens[26].rotation.z == 0 &&
            imagens[27].rotation.z == 0 &&
            imagens[28].rotation.z == 0 &&
            imagens[29].rotation.z == 0 &&
            imagens[30].rotation.z == 0 &&
            imagens[31].rotation.z == 0 &&
            imagens[32].rotation.z == 0 &&
            imagens[33].rotation.z == 0 &&
            imagens[34].rotation.z == 0 &&
            imagens[35].rotation.z == 0)
        {
            
            alanis = true;
            cantou.SetActive(true);
        }

    }
}
