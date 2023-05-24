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
    protected Dissolve dissolve;

    private void Awake()
    {
        anim = doorToOpen.GetComponent<Animator>();
        dissolve = doorToOpen.GetComponent<Dissolve>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canInteract = true;            
        }
    }

    protected virtual void OnTriggerExit(Collider other)
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
            if (anim != null)
            {
                anim.SetTrigger("OpenDoor");
            }

            if (dissolve != null)
            {
                dissolve.DissolveOut();
            }           

            Destroy(GetComponent<Collider>());
            Destroy(doorToOpen.GetComponent<Collider>());

            if (exitKeypad != null)
            {
                exitKeypad.SetActive(true);
            }
        }

        doorOpened = true;
    }
}
