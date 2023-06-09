using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CurrentDimension { NormalDimension, ShiftedDimension }

public class GameManager : MonoBehaviour
{
    [SerializeField] private CurrentDimension currentDimension;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentDimension = CurrentDimension.NormalDimension;
    }

    public CurrentDimension GetCurrentDimension()
    {
        return currentDimension;
    }

    public void SwitchDimension()
    {
        Debug.Log("Switching Dimensions");

        switch (currentDimension)
        {
            case CurrentDimension.NormalDimension:
                currentDimension = CurrentDimension.ShiftedDimension;
                break;
            case CurrentDimension.ShiftedDimension: 
                currentDimension = CurrentDimension.NormalDimension;
                break;
        }
    }
}
