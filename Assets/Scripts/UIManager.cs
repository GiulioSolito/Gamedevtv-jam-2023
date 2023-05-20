using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private GameObject keypadUI;

    public static UIManager Instance;
    
    private void OnEnable()
    {
        //Player.onInteractHover += ShowInteractText;
        //Player.onInteractHoverEnd += HideInteractText;
    }

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
        }
    }

    public void ShowInteractText(string text)
    {
        interactText.text = text;
    }

    public void HideInteractText()
    {
        interactText.text = "";
    }

    public void ShowKeypadUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        keypadUI.SetActive(true);
        //HideInteractText();
        //playerController.enabled = false;
    }

    public void HideKeypadUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //_keypadUI.SetActive(false);
        //_playerController.enabled = true;
    }

    void OnDisable()
    {
        //Player.onInteractHover -= ShowInteractText;
        //Player.onInteractHoverEnd -= HideInteractText;
    }
}
