using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private CurrentDimension blockInDimension;

    private Collider obstacleCollider;
    private MeshRenderer meshRenderer;

    private void OnEnable()
    {
        DimensionSwitcher.onDimensionSwitch += CheckDimensionState;
    }

    private void Awake()
    {
        obstacleCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void CheckDimensionState()
    {
        Debug.Log("Checking");

        if (GameManager.instance.GetCurrentDimension() == blockInDimension)
        {
            obstacleCollider.enabled = true;
            meshRenderer.enabled = true;
        }
        else
        {
            obstacleCollider.enabled = false;
            meshRenderer.enabled = false;
        }
    }

    private void OnDisable()
    {
        DimensionSwitcher.onDimensionSwitch -= CheckDimensionState;
    }
}
