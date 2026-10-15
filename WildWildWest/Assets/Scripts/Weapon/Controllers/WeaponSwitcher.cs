using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] private Weapon[] _weapons;

    private int _currentWeaponIndex = 0;

    public int CurrentWeaponIndex => _currentWeaponIndex;
    public Weapon CurrentWeapon => _weapons[_currentWeaponIndex];

    private void Start()
    {
        UpdateWeaponVisibility();
    }

    public void SwitchWeapon(float verticalScroll)
    {
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
            _weapons[i].gameObject.SetActive(i == _currentWeaponIndex);
    }
}