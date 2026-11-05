using System;

public interface IAnimationPlayer
{
    void EstablishSpeed(float movement);
    void EstablishForwardDirection(float direction);
    void EstablishJump(bool isJumping);
    void EstablishRun(bool isRunning);

    public void TriggerAttackPistol();
    public void TriggerAttackShovel();

    public event Action ShovelHit;
}