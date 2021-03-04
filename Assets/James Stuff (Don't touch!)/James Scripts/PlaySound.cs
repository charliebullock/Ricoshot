using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    // Start is called before the first frame update
    public void CreateSFX(AudioClip audioClip)
    {
        MenuSingleton menuSingleton = MenuSingleton.instance;

        menuSingleton.PlaySound(audioClip, transform.position, 0);
    }
}
