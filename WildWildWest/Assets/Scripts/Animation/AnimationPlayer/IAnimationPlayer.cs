using System;

public interface IAnimationPlayer
{
    void UpdateSpeed(float movement);
    void UpdateForwardDirection(float direction);
    void UpdateJumpState(bool isJumping);
    void UpdateRunState(bool isRunning);

    public void TriggerAttackPistol();
    public void TriggerAttackShovel();

    public event Action ShovelHit;
}