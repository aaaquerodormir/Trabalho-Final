using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraShake : MonoBehaviour
{
    public AnimationCurve curve;
    public float ShakeTime = 1.0f;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Shake());    
        }
    }
    public IEnumerator Shake()
    {
        Vector3 Startposition = transform.position;
        float TimeUsed = 0f;

        while(TimeUsed < ShakeTime)
        {
            TimeUsed += Time.deltaTime;
            float strength = curve.Evaluate(TimeUsed/ShakeTime);
            transform.position = Startposition + Random.insideUnitSphere * strength;
            yield return null;  

        }
        transform.position = Startposition;
    }

}
