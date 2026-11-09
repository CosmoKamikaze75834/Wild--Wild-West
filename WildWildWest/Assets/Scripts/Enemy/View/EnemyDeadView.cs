using UnityEngine;

public class EnemyDeadView : MonoBehaviour
{
    private const int EffectLifetime = 2;

    [SerializeField] private ParticleSystem _effect;

    public void CreateEffect(Vector3 enemyPosition)
    {
        var effect = Instantiate(_effect, enemyPosition, Quaternion.identity);
        Destroy(effect, EffectLifetime);
    }
}