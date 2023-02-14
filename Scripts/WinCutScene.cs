using UnityEngine;

public class WinCutScene : MonoBehaviour
{
    [SerializeField]
    private  GameObject _cutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.HasCard)
            {
                _cutscene.active = true;
            }
            else
            {
                Debug.Log("You must have a card");
            }
        }
    }
}
