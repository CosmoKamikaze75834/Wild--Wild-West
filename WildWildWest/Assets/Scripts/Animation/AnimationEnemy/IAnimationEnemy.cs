using System;

public interface IAnimationEnemy
{
    public void TriggerAttack();
    public event Action AttackHit;
}