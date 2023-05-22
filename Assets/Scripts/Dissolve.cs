using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    private Renderer[] renderers;

    [SerializeField] private float dissolveInSpeed = 0.2f;
    [SerializeField] private float dissolveOutSpeed = 0.2f;
    [Range(0,1)] [SerializeField] private float dissolve = 1f;

    public bool isDissolvingIn = false;
    public bool isDissolvingOut = false;

    private void Awake()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    private void OnEnable()
    {
        dissolve = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        Dissolving();
    }

    private void Dissolving()
    {
        if (isDissolvingIn)
        {
            dissolve -= dissolveInSpeed * Time.deltaTime;

            foreach (var renderer in renderers)
            {
                foreach (var material in renderer.materials)
                {
                    material.SetFloat("_Dissolve", dissolve);
                }
            }

            if (dissolve < 0)
            {
                isDissolvingIn = false;
                dissolve = 0;
            }
        }
        else if (isDissolvingOut)
        {
            dissolve += dissolveOutSpeed * Time.deltaTime;

            foreach (var renderer in renderers)
            {
                foreach (var material in renderer.materials)
                {
                    material.SetFloat("_Dissolve", dissolve);
                }
            }
            
            if (dissolve > 1)
            {
                isDissolvingOut = false;
                dissolve = 1;
            }
        }
    }

    public void DissolveIn()
    {
        isDissolvingIn = true;
    }

    public void DissolveOut()
    {
        isDissolvingOut = true;
    }
}
