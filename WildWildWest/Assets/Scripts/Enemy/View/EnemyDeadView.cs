using UnityEngine;

public class EnemyDeadView : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void CreateEffect(Vector3 enemyPosition)
    {
        var effect = Instantiate(_effect, enemyPosition, Quaternion.identity);
        
        Destroy(effect, 2f);
    }
}