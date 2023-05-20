using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwitcher : MonoBehaviour
{
    private CurrentDimension currentDimension;

    // Start is called before the first frame update
    private void Start()
    {
        currentDimension = GameManager.instance.GetCurrentDimension();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentDimension = GameManager.instance.GetCurrentDimension();
        }
    }
}
