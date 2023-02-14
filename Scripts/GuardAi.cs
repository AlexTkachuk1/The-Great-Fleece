using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAi : MonoBehaviour
{
    [SerializeField]
    private List<Transform> wayPoints;
    private Transform currentTarget;
    private NavMeshAgent _guardMesh;
    private int _counter = 0;
    private bool _reverse = false;
    private bool canGo = true;
    private bool isWalking = false;
    private Animator _animator;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _guardMesh = GetComponent<NavMeshAgent>();
        if (wayPoints.Count > 0)
        {
            currentTarget = wayPoints[_counter];
            _guardMesh.SetDestination(currentTarget.position);
        }
    }

    void Update()
    {
        if (currentTarget != null)
        {
            _guardMesh.SetDestination(currentTarget.position);
        }

        if (currentTarget != null)
        {
            float distance = Vector3.Distance(transform.position, currentTarget.position);


            if (distance < 1.5f && canGo)
            {
                if (_counter == wayPoints.Count - 1 || _counter == 0)
                {
                    canGo = false;
                    StartCoroutine(WaitBeforeMovingCoroutine());
                }
                else
                {
                    SetNewTarget();
                }
            }

            isWalking = distance > 1.5f;
            _animator.SetBool("Walk", isWalking);
        }
    }

    private void SetNewTarget()
    {
        if (_counter == wayPoints.Count - 1 || _counter == 0)
        {
            _reverse = !_reverse;
        }
        _counter = _reverse ? ++_counter : --_counter;
        currentTarget = wayPoints[_counter];
    }

    public void SetNewTarget(Transform position)
    {
        currentTarget = position;
    }

    IEnumerator WaitBeforeMovingCoroutine()
    {
        yield return new WaitForSeconds(Random.Range(1f, 5f));
        SetNewTarget();
        canGo = true;
    }
}
