using UnityEngine;

public class GrabCutScene : MonoBehaviour
{
    [SerializeField]
    private GameObject _cutscene;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform _finishDarrenPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _cutscene.active = true;
            _player.transform.position = _finishDarrenPosition.position;
            _player.transform.rotation = _finishDarrenPosition.rotation;
            _player.GetComponent<Player>().setTarget(_finishDarrenPosition.position);
            GameManager.Instance.HasCard = true;
        }
    }
}
