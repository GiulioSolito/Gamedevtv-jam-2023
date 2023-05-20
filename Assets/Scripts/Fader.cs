using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fader : MonoBehaviour
{
    private Animator animator;
    private PlayerInput playerInput;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInput = FindAnyObjectByType<PlayerInput>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
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

    public void DisableInput()
    {
        playerInput.enabled = false;
    }

    public void EnableInput()
    {
        playerInput.enabled = true;
    }
}
