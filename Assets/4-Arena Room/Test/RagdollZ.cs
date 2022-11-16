using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RagdollZ : MonoBehaviour
{
    private enum ChangeState
    { 
        Normal,
        Ragdoll
    }
    //public Rigidbody mainRB;

    private Rigidbody[] _ragdollRigidbodies;
    private Collider[] _colliders;
    private Collider _mainCollider;
    private ChangeState _currentState = ChangeState.Normal;
    private Animator _animator;
    private EnemiAI _enemyAI;
    private Rigidbody _rigidBody;

    [HideInInspector] public bool Button;

    public UnityEvent Call;
    bool callOnce;

    void Awake()
    {
        //mainRB = gameObject.transform.GetChild(0).GetChild(0).GetComponent<Rigidbody>();

        _ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        _mainCollider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
        _enemyAI = GetComponent<EnemiAI>();
        _rigidBody = GetComponent<Rigidbody>();
        DisableRagdoll();
    }

    void Update()
    {
        switch (_currentState)
        {
            case ChangeState.Normal:
                NormalBehaviour();
                break;
            case ChangeState.Ragdoll:
                RagdollBehaviour();
                break;
        }


        if (callOnce == true)
        {
            Call.Invoke();
            callOnce = false;
        }
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }

        foreach (var collider in _colliders)
        {
            collider.enabled = false;
        }

        _animator.enabled = true;
        _enemyAI.enabled = true;
        _rigidBody.isKinematic = false;
        _mainCollider.enabled = true;
    }

    private void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }

        foreach (var collider in _colliders)
        {
            collider.enabled = true;
        }

        _animator.enabled = false;
        _enemyAI.enabled = false;
        _rigidBody.isKinematic = true;
        _mainCollider.enabled = false;

        callOnce = true;
    }

    private void NormalBehaviour()
    {
        if (Button == true)
        {
            EnableRagdoll();
            _currentState = ChangeState.Ragdoll;
        }
    }

    private void RagdollBehaviour()
    { 
    
    }

    public void LOL()
    {
        Debug.Log("LOL");
    }
}
