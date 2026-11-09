public interface IPlayerMovementAnimation
{
    void UpdateSpeed(float movement);
    void UpdateForwardDirection(float direction);
    void UpdateJumpState(bool isJumping);
    void UpdateRunState(bool isRunning);
}