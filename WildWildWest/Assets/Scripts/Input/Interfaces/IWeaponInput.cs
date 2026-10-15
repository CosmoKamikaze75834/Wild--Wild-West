using UnityEngine;

public interface IWeaponInput
{
    public bool IsAttack { get;}
    public Vector2 ScrollDelta { get;}

    public Vector2 ConsumeScrollDelta();
}