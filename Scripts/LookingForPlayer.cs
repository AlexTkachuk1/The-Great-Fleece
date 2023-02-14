using UnityEngine;

public class LookingForPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameOverCutscene.active = true;
        }
    }
}
