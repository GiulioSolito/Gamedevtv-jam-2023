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

    private void Start()
    {
        CheckDimensionState();
    }

    protected virtual void CheckDimensionState()
    {

    }

    private void OnDisable()
    {
        DimensionSwitcher.onDimensionSwitch -= CheckDimensionState;
    }
}
