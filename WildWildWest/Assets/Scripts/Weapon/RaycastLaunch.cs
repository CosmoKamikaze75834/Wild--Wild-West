using UnityEngine;

public class RaycastLaunch : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private LayerMask _layerMask;

    public bool TryGetHit(out RaycastHit hitObject)
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            hitObject = hitInfo;//получили игровой объект в который попал луч

            return true;
        }

        hitObject = default;
        return false;
    }

    private void OnDrawGizmos()
    {
        if (_camera == null)
            return;

        Ray ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        Gizmos.color = Color.yellow;

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            Gizmos.DrawLine(ray.origin, hitInfo.point);
            Gizmos.DrawSphere(hitInfo.point, 0.1f);
        }
        else
        {
            Gizmos.DrawLine(ray.origin,ray.origin + ray.direction * _maxDistance);
        }
    }
}