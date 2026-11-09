using UnityEngine;
using Zenject;

public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private WeaponSwitcher _weaponSwitcher;

    private IWeaponInput _weaponInput;
    private IPlayerCombatAnimation _animationPlayer;

    private bool _wasAttackPressed;

    private void OnEnable()
    {
        _animationPlayer.ShovelHit += HandleShovelHit;
    }

    private void OnDisable()
    {
        _animationPlayer.ShovelHit -= HandleShovelHit;
    }

    private void HandleShovelHit()
    {
        Weapon currentWeapon = _weaponSwitcher.CurrentWeapon;

        if (currentWeapon is Shovel)
        {
            currentWeapon.Attack();
        }
    }

    private void Update()
    {
        _weaponSwitcher.SwitchWeapon(_weaponInput.ConsumeScrollDelta.y);

        HandleAttack();
    }

    private void HandleAttack()
    {
        bool isAttackPressed = _weaponInput.IsAttack;

        if (isAttackPressed && !_wasAttackPressed)
        {
            Weapon currentWeapon = _weaponSwitcher.CurrentWeapon;

            if (currentWeapon is Pistol)
            {
                _animationPlayer.TriggerAttackPistol();
                currentWeapon.Attack();
            }
            else if (currentWeapon is Shovel)
                _animationPlayer.TriggerAttackShovel();
        }

        _wasAttackPressed = isAttackPressed;
    }

    [Inject]
    private void Construct(IWeaponInput weaponInput, IPlayerCombatAnimation animationPlayer)
    {
        _weaponInput = weaponInput;
        _animationPlayer = animationPlayer;
    }
}