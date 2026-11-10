using UnityEngine;

public class RaycastLaunch : MonoBehaviour
{
    private const float ViewportCenter = 0.5f;
    private const float RayOriginDepth = 0f;

    [SerializeField] private Camera _camera;
    [SerializeField] private float _maxDistance = 100f;
    [SerializeField] private LayerMask _layerMask;

    public bool TryGetHit(out RaycastHit hitObject)
    {
        Ray ray = _camera.ViewportPointToRay(new Vector3(ViewportCenter, ViewportCenter, RayOriginDepth));

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _maxDistance, _layerMask, QueryTriggerInteraction.Ignore))
        {
            hitObject = hitInfo;
            return true;
        }

        hitObject = default;
        return false;
    }
}