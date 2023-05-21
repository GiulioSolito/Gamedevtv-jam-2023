using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : DimensionObject
{
    private Collider obstacleCollider;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        obstacleCollider = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    protected override void CheckDimensionState()
    {
        base.CheckDimensionState();

        if (GameManager.instance.GetCurrentDimension() == enableInDimension)
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
}
