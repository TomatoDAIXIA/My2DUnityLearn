using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Block 
{
    [SerializeField]
    private GameObject first, second;

    public void SetBlockActive(bool active)
    {
        first.SetActive(active);
        second.SetActive(active);
    }
}
