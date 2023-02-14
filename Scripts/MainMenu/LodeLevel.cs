using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LodeLevel : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    private void Start()
    {
        StartCoroutine(LodeLevelAsync());
    }

    IEnumerator LodeLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(1);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            //Output the current progress
            _progressBar.fillAmount = asyncOperation.progress;

            // Check if the load has finished
            if (asyncOperation.isDone)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
