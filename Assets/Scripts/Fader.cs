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
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = FindAnyObjectByType<PlayerInput>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Fade();
        }
    }

    public void Fade()
    {
        animator.SetTrigger("Fade");        
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
    }
}
