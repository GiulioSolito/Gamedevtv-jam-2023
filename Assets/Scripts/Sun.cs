using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private GameObject shiftedLight;

    private void OnEnable()
    {
        DimensionSwitcher.onDimensionSwitch += CheckDimension;
    }

    private void Start()
    {
        CheckDimension();
    }

    private void CheckDimension()
    {
        if (GameManager.instance.GetCurrentDimension() == CurrentDimension.NormalDimension)
        {
            SetNormalSun();
        }
        else
        {
            SetShiftedSun();
        }
    }

    private void SetNormalSun()
    {
        transform.localEulerAngles = new Vector3(50f, -30f, 0f);
        shiftedLight.SetActive(false);
    }

    private void SetShiftedSun()
    {
        transform.localEulerAngles = new Vector3(-8f, -30f, 0f);
        shiftedLight.SetActive(true);
    }

    private void OnDisable()
    {
        DimensionSwitcher.onDimensionSwitch -= CheckDimension;
    }
}
