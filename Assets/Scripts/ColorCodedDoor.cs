using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCodedDoor : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonsToOpenDoor;
    [SerializeField] private GameObject[] buttonIdicators;

    [SerializeField] private Material[] glowMaterials;

    public List<GameObject> activatedButtons;

    private bool destroyOnTrigger = false;

    private void OnEnable()
    {
        ColorCodedDoorButton.onActivateButton += LightUpIndicators;
    }

    private void LightUpIndicators(int indicator)
    {
        buttonIdicators[indicator].GetComponent<MeshRenderer>().material = glowMaterials[indicator];

        CheckIndicators();
    }

    private void CheckIndicators()
    {
        foreach (var button in buttonsToOpenDoor)
        {
            if (button.GetComponent<ColorCodedDoorButton>().CheckActive() == true)
            {
                activatedButtons.Add(button);
            }
        }

        if (activatedButtons.Count >= 3)
        {
            destroyOnTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && destroyOnTrigger)
        {
            GetComponent<Dissolve>().DissolveOut();
            
            foreach (Collider collider in GetComponents<Collider>())
            {
                Destroy(collider);
            }
        }
    }
}
