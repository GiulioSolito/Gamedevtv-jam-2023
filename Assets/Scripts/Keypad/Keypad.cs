using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Keypad : MonoBehaviour
{
    [SerializeField] private string codeToUnlock = "0000";
    [SerializeField] private string codeEntered;
    [SerializeField] private TextMeshProUGUI codeText;
    [SerializeField] private int maxAllowedNumbers = 4;

    public static Action onCorrectCodeEntered;

    public bool correctCodeEntered = false;

    public void OnEnable()
    {
        KeypadTrigger.onSetCode += SetCode;

        codeEntered = "";
        codeText.text = "CODE";
    }

    public void SetCode(string code)
    {
        codeToUnlock = code;
    }

    public void AddKeyToCode(string key)
    {
        if (codeEntered.Length < maxAllowedNumbers)
        {
            codeEntered += key;
            codeText.text = codeEntered;
        }
    }

    public void SubmitCode()
    {
        if (codeText.text == codeToUnlock)
        {
            Debug.Log("You have entered the correct code!");
            correctCodeEntered = true;

            if (onCorrectCodeEntered != null)
            {
                onCorrectCodeEntered();
            }
        }
        else
        {
            Debug.Log("You have entered the incorrect code!");
            codeEntered = "";
            codeText.text = "";
        }
    }

    public void ClearCode()
    {
        KeypadTrigger.onSetCode -= SetCode;

        codeEntered = "";
        codeText.text = "";
    }
}
