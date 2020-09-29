using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button[] actionButtons;

    private KeyCode aciton1, aciton2, aciton3;


    // Start is called before the first frame update
    void Start()
    {
        aciton1 = KeyCode.J;
        aciton2 = KeyCode.K;
        aciton3 = KeyCode.L;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(aciton1))
        {
            ActionButtonClick(0);
        }

        if (Input.GetKeyDown(aciton2))
        {
            ActionButtonClick(1);
        }

        if (Input.GetKeyDown(aciton3))
        {
            ActionButtonClick(2);
        }
    }

    private void ActionButtonClick(int btnIndex)
    {
        actionButtons[btnIndex].onClick.Invoke();
    }
}
