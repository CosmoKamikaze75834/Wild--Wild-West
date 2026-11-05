using System;
using UnityEngine;

public class WeaponAnimationEvents : MonoBehaviour
{
    public event Action ShovelHit;

    public void OnShovelHit()
    {
        Debug.Log("Наносим урон");
        ShovelHit?.Invoke();
    }
}