using UnityEngine;
using UnityEngine.Playables;

public class SkipIntroCutscene : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector introCutscene;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            introCutscene.time = 60.0f;
        }
    }
}
