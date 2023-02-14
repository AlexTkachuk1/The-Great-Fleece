using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject[] guards; 
    [SerializeField]
    private AudioClip clip;
    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, transform.position);
        guards = GameObject.FindGameObjectsWithTag("Guard1");
        SendAiToCoinPoint(transform);
    }

    private void SendAiToCoinPoint(Transform coinTransform)
    {
        foreach(GameObject guard in guards)
        {
            guard.GetComponent<GuardAi>().SetNewTarget(coinTransform);
        }
    }
}
