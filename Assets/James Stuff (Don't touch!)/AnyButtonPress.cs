﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyButtonPress : MonoBehaviour
{

    [SerializeField] int PlayLevel = 1;
    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            MenuSingleton.instance.ChangeLevel(PlayLevel);
        }
    }
}
