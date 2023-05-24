using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject fader;
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private GameObject keypadUI;

    private PlayerInput playerInput;

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

        playerInput = FindObjectOfType<PlayerInput>();
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
        keypadUI.GetComponent<CanvasGroup>().alpha = 1;
        HideInteractText();
        playerInput.enabled = false;
    }

    public void HideKeypadUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        keypadUI.GetComponent<CanvasGroup>().alpha = 0;
        playerInput.enabled = true;
    }

    private void OnDisable()
    {
        //Player.onInteractHover -= ShowInteractText;
        //Player.onInteractHoverEnd -= HideInteractText;
    }
}
