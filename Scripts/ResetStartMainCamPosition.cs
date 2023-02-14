using UnityEngine;

public class ResetStartMainCamPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject _firstCam;
    void Start()
    {
        transform.position = _firstCam.transform.position;
        transform.rotation = _firstCam.transform.rotation;
    }
}
