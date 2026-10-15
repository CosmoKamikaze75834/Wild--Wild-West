using UnityEngine;

public interface IAnimationPlayer
{
    void EstablishSpeed(float movement);
    void EstablishJump(bool isJumping);
    void EstablishRun(bool isRunning);
    public void TriggerAttackPistol();
    public void TriggerAttackShovel();
}