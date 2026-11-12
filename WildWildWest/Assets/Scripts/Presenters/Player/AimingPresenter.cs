using UnityEngine;

public class AimingPresenter : MonoBehaviour
{
    [SerializeField] private Aiming _aiming;
    [SerializeField] private AimView _aimView;

    private void OnEnable()
    {
        _aiming.AimStateChanged += HandleAimChanged;
    }

    private void OnDisable()
    {
        _aiming.AimStateChanged -= HandleAimChanged;
    }

    private void HandleAimChanged(bool isAiming)
    {
        if (isAiming)
            _aimView.Open();
        else
            _aimView.Close();
    }
}