using UnityEngine;

public class AimingPresenter : MonoBehaviour
{
    [SerializeField] private Aiming _aiming;
    [SerializeField] private AimView _aimView;

    private void OnEnable()
    {
        _aiming.OnAimStateChanged += HandleAimChanged;
    }

    private void OnDisable()
    {
        _aiming.OnAimStateChanged -= HandleAimChanged;
    }

    private void HandleAimChanged(bool isAiming)
    {
        if (isAiming)
            _aimView.Open();
        else
            _aimView.Close();
    }
}