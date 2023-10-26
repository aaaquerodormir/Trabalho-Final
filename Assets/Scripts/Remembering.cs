using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remembering : MonoBehaviour
{
    [SerializeField]
    string keyname;
    [SerializeField]
    bool enableRemembering = false;
    // Start is called before the first frame update
    void Start()
    {
        
        if (enableRemembering)
        {
            keyname = gameObject.name;
            if (keyname.Length > 0)
            {
                if (PlayerPrefs.HasKey(keyname))
                {
                    transform.position = PlayerPrefsX.GetVector3(keyname);
                }
                InvokeRepeating("InaSecond", 0, 1);
            }
        }
    }

   void InaSecond()
    {
        PlayerPrefsX.SetVector3(keyname, transform.position);
        PlayerPrefs.Save();
    }
}
