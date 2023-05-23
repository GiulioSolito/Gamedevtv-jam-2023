using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCodedDoorButton : MonoBehaviour
{
    [SerializeField] private bool isActive = false;

    [SerializeField] private Material glowMaterial;

    [Range(0,2)][SerializeField] private int buttonNumber = 0;

    private bool canInteract = false;

    public static Action<int> onActivateButton;

    private void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                isActive = true;
                GetComponent<MeshRenderer>().material = glowMaterial;
                GetComponent<Collider>().enabled = false;
                UIManager.Instance.HideInteractText();

                onActivateButton?.Invoke(buttonNumber);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = true;
            UIManager.Instance.ShowInteractText("Button");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canInteract = false;
            UIManager.Instance.HideInteractText();
        }
    }

    public bool CheckActive()
    {
        return isActive;
    }
}
