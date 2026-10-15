using UnityEngine;
using Zenject;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher _weaponSwitcher;

    private IWeaponInput _weaponInput;
    private IAnimationPlayer _animationPlayer;

    private bool _wasAttackPressed;

    private void Update()
    {
        _weaponSwitcher.SwitchWeapon(_weaponInput.ConsumeScrollDelta().y);

        HandleAttack();
    }

    private void HandleAttack()
    {
        bool isAttackPressed = _weaponInput.IsAttack;

        if (isAttackPressed && !_wasAttackPressed)
        {
            Weapon currentWeapon = _weaponSwitcher.CurrentWeapon;

            if (currentWeapon is Pistol)
                _animationPlayer.TriggerAttackPistol();
            else if(currentWeapon is Shovel)
                _animationPlayer.TriggerAttackShovel();

            currentWeapon.Attack();
        }

        _wasAttackPressed = isAttackPressed;
    }

    [Inject]
    private void Construct(IWeaponInput weaponInput, IAnimationPlayer animationPlayer)
    {
        _weaponInput = weaponInput;
        _animationPlayer = animationPlayer;
    }
}