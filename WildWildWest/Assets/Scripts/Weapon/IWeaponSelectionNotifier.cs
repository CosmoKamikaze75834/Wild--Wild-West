using System;

public interface IWeaponSelectionNotifier
{
    public event Action<Weapon> WeaponChanged;
}