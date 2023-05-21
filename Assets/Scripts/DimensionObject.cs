using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DimensionObject : MonoBehaviour
{
    [SerializeField] protected CurrentDimension enableInDimension;

    private void OnEnable()
    {
        DimensionSwitcher.onDimensionSwitch += CheckDimensionState;
    }

    protected virtual void CheckDimensionState()
    {
        Debug.Log("Checking");
    }

    private void OnDisable()
    {
        DimensionSwitcher.onDimensionSwitch -= CheckDimensionState;
    }
}
