using System;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour, IWeaponSelectionNotifier
{
    private const int InitialWeaponIndex = 0;
    private const int NextWeaponStep = 1;
    private const int PreviousWeaponStep = -1;
    private const float NoScroll = 0f;

    [SerializeField] private Weapon[] _weapons;

    private int _currentWeaponIndex = InitialWeaponIndex;

    public int CurrentWeaponIndex => _currentWeaponIndex;
    public Weapon CurrentWeapon => _weapons[_currentWeaponIndex];

    public event Action<Weapon> WeaponChanged;

    private void Start()
    {
        UpdateWeaponVisibility();
    }

    public void SwitchWeapon(float verticalScroll)
    {
        if (verticalScroll == NoScroll)
            return;

        int direction = verticalScroll > NoScroll ? NextWeaponStep : PreviousWeaponStep;

        _currentWeaponIndex = (_currentWeaponIndex + direction + _weapons.Length) % _weapons.Length;

        UpdateWeaponVisibility();
    }

    private void UpdateWeaponVisibility()
    {
        for (int i = InitialWeaponIndex; i < _weapons.Length; i++)
            _weapons[i].gameObject.SetActive(i == _currentWeaponIndex);

        WeaponChanged?.Invoke(CurrentWeapon);
    }
}