using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Puzzle : MonoBehaviour
{
    [SerializeField] protected string codeToUnlock = "0000";
    [SerializeField] protected string codeEntered;
    [SerializeField] protected GameObject doorToOpen;
    [SerializeField] protected GameObject exitKeypad;

    protected bool canInteract = false;
    protected bool doorOpened = false;

    protected Animator anim;

    private void Start()
    {
        anim = doorToOpen.GetComponent<Animator>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = true;
            UIManager.Instance.ShowInteractText("Key Pad");
        }
    }

    public virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = false;
            UIManager.Instance.HideInteractText();
        }
    }

    public virtual void OpenDoor()
    {
        if (doorToOpen != null)
        {
            anim.SetTrigger("OpenDoor");
            Destroy(GetComponent<Collider>());

            if (exitKeypad != null)
            {
                exitKeypad.SetActive(true);
            }
        }

        doorOpened = true;
    }
}
