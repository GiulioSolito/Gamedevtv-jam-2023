using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCode : DimensionObject
{
    [SerializeField] private GameObject[] objectsToShift;

    protected override void CheckDimensionState()
    {
        base.CheckDimensionState();

        if (GameManager.instance.GetCurrentDimension() == enableInDimension)
        {
            foreach (var obj in objectsToShift)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (var obj in objectsToShift)
            {
                obj.SetActive(false);
            }
        }
    }
}
