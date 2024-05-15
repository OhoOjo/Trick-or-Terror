using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    Toggle toggleSound;
    // Start is called before the first frame update
    void Start()
    {
        toggleSound = GetComponent<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SoundOff()
    {

        if (toggleSound.isOn)
        {
            AudioListener.volume = 1;
        }
        else if (!toggleSound.isOn)
        {
            AudioListener.volume = 0;
        }
    }
}
