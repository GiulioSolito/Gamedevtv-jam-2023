using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DimensionSwitcher : MonoBehaviour
{
    [SerializeField] private Transform exitPoint;

    private CurrentDimension currentDimension;

    private GameObject player;

    private AudioSource audioSource;

    public static Action onDimensionSwitch;

    private void OnEnable()
    {
        Fader.onFadeComplete += MovePlayer;
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        currentDimension = GameManager.instance.GetCurrentDimension();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            GameManager.instance.SwitchDimension();
            currentDimension = GameManager.instance.GetCurrentDimension();

            onDimensionSwitch?.Invoke();
            audioSource.Play();
        }
    }

    private void MovePlayer()
    {
        StartCoroutine(MovePlayerRoutine());
    }

    private IEnumerator MovePlayerRoutine()
    {
        if (exitPoint != null)
        {
            if (player == null) yield break;
            //player.GetComponent<ThirdPersonController>().enabled = false;
            player.GetComponent<FirstPersonController>().enabled = false;
            player.transform.position = exitPoint.position;            
            
            yield return new WaitForSeconds(1);
            //player.GetComponent<ThirdPersonController>().enabled = true;
            player.GetComponent <FirstPersonController>().enabled = true;
        }
    }

    private void OnDisable()
    {
        Fader.onFadeComplete -= MovePlayer;
    }
}
