using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject _cameraTrigger;
    [SerializeField]
    private GameObject _mainCamera;
    [SerializeField]
    private GameObject _cameraEtalon;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _mainCamera.transform.position = _cameraEtalon.transform.position;
            _mainCamera.transform.rotation = _cameraEtalon.transform.rotation;
        }
    }
}