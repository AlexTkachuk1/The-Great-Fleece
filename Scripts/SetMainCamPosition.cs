using UnityEngine;

public class SetMainCamPosition : MonoBehaviour
{
    [SerializeField]
    private GameObject _mainCam;

    void Start()
    {
        transform.position = _mainCam.transform.position;
        transform.rotation = _mainCam.transform.rotation;
    }
}
