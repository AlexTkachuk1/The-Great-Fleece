using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject _coinPrefab;
    private NavMeshAgent _playerMesh;
    private Animator _animator;
    private bool isWalking = false;
    private bool isThrowing = false;
    private Vector3 _target;
    private Vector3 _coinTarget;
    [SerializeField]
    private int amountOfCoins;
    void Start()
    {
        _target = transform.position;
        _playerMesh = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                _playerMesh.destination = hitInfo.point;
                _target = hitInfo.point;
            }
        }
        float distance = Vector3.Distance(transform.position, _target);

        isWalking = distance > 1.5f;
        _animator.SetBool("Walk", isWalking);

        if (Input.GetMouseButtonDown(1) && !isThrowing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (amountOfCoins > 0)
                {
                    isThrowing = true;
                    _animator.SetTrigger("Throw");
                    amountOfCoins--;
                    _coinTarget = hitInfo.point;
                    StartCoroutine(ThrowTheCoinCoroutine());
                }
            }
        }
    }

    public void setTarget(Vector3 position)
    {
        _target = position;
    }
    IEnumerator ThrowTheCoinCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Instantiate(_coinPrefab, _coinTarget, Quaternion.identity);
        isThrowing = false;
    }
}
