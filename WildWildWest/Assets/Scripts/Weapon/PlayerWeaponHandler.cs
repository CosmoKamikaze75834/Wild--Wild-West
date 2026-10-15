using UnityEngine;
using Zenject;

//посредник между вводом игрока и оружием
public class PlayerWeaponHandler : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;

    private int _currentWeaponIndex = 0;

    private IWeaponInput _weaponInput;
    private IAnimationPlayer _animationPlayer;

    private bool _wasAttackPressed;//чтобы отличить нажатие от длительного удержания кнопки

    private void Start()
    {
        UpdateWeaponVisibility();
    }

    private void Update()
    {
        SwitchWeapon();

        bool isAttackPressed = _weaponInput.IsAttack;//текущее состояние кнопки

        if (isAttackPressed && !_wasAttackPressed)//была отпущена и нажата
        {
            if (_weapons[_currentWeaponIndex] is Pistol)
                _animationPlayer.TriggerAttackPistol();
            else
                _animationPlayer.TriggerAttackShovel();

            _weapons[_currentWeaponIndex].Attack();
        }

        _wasAttackPressed = isAttackPressed;
    }

    private void SwitchWeapon()
    {
        var verticalScroll = _weaponInput.ConsumeScrollDelta().y;

        if (verticalScroll > 0)
        {
            _currentWeaponIndex = (_currentWeaponIndex + 1) % _weapons.Length;
            UpdateWeaponVisibility();
        }
        else if (verticalScroll < 0)
        {
            _currentWeaponIndex = (_currentWeaponIndex - 1 + _weapons.Length) % _weapons.Length;
            UpdateWeaponVisibility();
        }
    }

    private void UpdateWeaponVisibility()
    {
        for (int i = 0; i < _weapons.Length; i++)
        {
            _weapons[i].gameObject.SetActive(i == _currentWeaponIndex);
        }
    }

    [Inject]
    private void Construct(IWeaponInput weaponInput, IAnimationPlayer animationPlayer)
    {
        _weaponInput = weaponInput;
        _animationPlayer = animationPlayer;
    }
}