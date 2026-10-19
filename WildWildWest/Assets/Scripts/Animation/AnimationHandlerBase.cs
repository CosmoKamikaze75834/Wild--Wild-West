using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class AnimationHandlerBase : MonoBehaviour
{
    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
