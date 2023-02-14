using UnityEngine;

public class VoceOverTrigger : MonoBehaviour
{
    [SerializeField]
    private AudioClip audioClip;
    [SerializeField]
    private Transform point;
    private bool diallogIsTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !diallogIsTriggered)
        {
            diallogIsTriggered = true;
            AudioManager.Instance.PlayAudio(audioClip);
        }
    }
}
