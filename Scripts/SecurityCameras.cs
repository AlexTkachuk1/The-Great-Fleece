using System.Collections;
using UnityEngine;

public class SecurityCameras : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverCutscene;
    private Animator _animator;
    private MeshRenderer _meshRenderer;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Color newColor = new Color(0.6f, .1f, .1f, 0.3f);
            _meshRenderer.material.SetColor("_TintColor", newColor);
            _animator.enabled = false;
            StartCoroutine(StartGameOverCutsceneCorutine());
        }
    }

    IEnumerator StartGameOverCutsceneCorutine()
    {
        yield return new WaitForSeconds(0.5f);
        _gameOverCutscene.active = true;
    }
}
