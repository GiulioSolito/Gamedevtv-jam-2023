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

    public GameObject activePuzzle = null;

    public void OnEnable()
    {
        KeypadTrigger.onSetCode += SetCode;
        KeypadTrigger.onEnterTrigger += SetActivePuzzle;
        KeypadTrigger.onExitTrigger += ResetActivePuzzle;

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

            activePuzzle.GetComponent<KeypadTrigger>().OpenDoor();
            codeEntered = "";
            codeText.text = "CODE";
            correctCodeEntered = false;
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
        codeEntered = "";
        codeText.text = "";
    }

    private void SetActivePuzzle(GameObject currentActivePuzzle)
    {
        activePuzzle = currentActivePuzzle;
    }

    private void ResetActivePuzzle()
    {
        activePuzzle = null;
    }

    public void OnDisable()
    {
        KeypadTrigger.onSetCode -= SetCode;
        KeypadTrigger.onEnterTrigger -= SetActivePuzzle;
        KeypadTrigger.onExitTrigger -= ResetActivePuzzle;
    }
}
