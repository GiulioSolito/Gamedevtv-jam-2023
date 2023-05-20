using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadTrigger : Puzzle
{
    public static Action<string> onSetCode;

    private void OnEnable()
    {
        Keypad._OnCorrectCodeEntered += OpenDoor;
    }

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0)) && canInteract && !doorOpened)
        {
            UIManager.Instance.ShowKeypadUI();
            SendCodeToKeypad();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canInteract)
        {
            UIManager.Instance.HideKeypadUI();
        }
    }

    public override void OnTriggerExit(Collider other)
    {
        base.OnTriggerExit(other);
        UIManager.Instance.HideKeypadUI();
    }

    private void SendCodeToKeypad()
    {
        if (onSetCode != null)
        {
            onSetCode(codeToUnlock);
        } 
    }

    public override void OpenDoor()
    {
        base.OpenDoor();
        Debug.Log("Correct code entered! Opening Door");
        UIManager.Instance.HideKeypadUI();   
    }

    private void OnDisable()
    {
        Keypad._OnCorrectCodeEntered -= OpenDoor;
    }
}
