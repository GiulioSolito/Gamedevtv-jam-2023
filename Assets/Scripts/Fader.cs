using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fader : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    public static Action onFadeComplete;

    private void OnEnable()
    {
        DimensionSwitcher.onDimensionSwitch += Fade;
        Exit.onCompleteLevel += Fade;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = FindAnyObjectByType<PlayerInput>();
    }

    private void Start()
    {
        if (animator != null)
        {
            animator.SetTrigger("FadeOut");
        }
    }

    public void Fade()
    {
        if (animator != null)
        {
            animator.SetTrigger("Fade");
        }
    }

    public void FadeComplete()
    {
        onFadeComplete?.Invoke();
    }

    public void DisableInput()
    {
        playerInput.enabled = false;        
    }

    public void EnableInput()
    {
        playerInput.enabled = true;        
    }

    private void OnDisable()
    {
        DimensionSwitcher.onDimensionSwitch -= Fade;
        Exit.onCompleteLevel -= Fade;
    }
}
