using System;

public interface IPlayerCombatAnimation
{
    public void TriggerAttackPistol();
    public void TriggerAttackShovel();

    public event Action ShovelHit;
}