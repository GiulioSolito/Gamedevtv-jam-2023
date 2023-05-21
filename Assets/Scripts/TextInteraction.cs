using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextInteraction : DimensionObject
{
    [TextArea]
    [SerializeField] private string textToShow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.instance.GetCurrentDimension() == enableInDimension)
            {
                if (textToShow != null)
                {
                    UIManager.Instance.ShowInteractText(textToShow);
                }
            }
            else
            {
                if (textToShow != null)
                {
                    UIManager.Instance.HideInteractText();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIManager.Instance.HideInteractText();
        }
    }
}
