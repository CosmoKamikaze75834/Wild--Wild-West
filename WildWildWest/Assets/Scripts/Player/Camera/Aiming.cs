using System;
using UnityEngine;
using Zenject;

public class Aiming : MonoBehaviour
{
    private const float AimCameraXPosition = 0.49f;

    [SerializeField] private Camera _camera;
    [SerializeField] private float _defaultFov;
    [SerializeField] private float _aimFov;

    private IWeaponInput _weaponInput;
    private IWeaponSelectionNotifier _notifier;

    private Vector3 _defaultCameraPosition;
    private Vector3 _aimCameraPosition;

    private bool _previousState;
    private bool _canAim;

    public event Action<bool> AimStateChanged;

    private void Start()
    {
        _defaultCameraPosition = _camera.transform.localPosition;
        _aimCameraPosition = new Vector3(AimCameraXPosition, _defaultCameraPosition.y, _defaultCameraPosition.z);
    }

    private void OnEnable()
    {
        _notifier.WeaponChanged += HandleWeaponChanged;
    }

    private void OnDisable()
    {
        _notifier.WeaponChanged -= HandleWeaponChanged;
    }

    private void Update()
    {
        bool currentState = _weaponInput.IsAiming && _canAim;

        if (currentState != _previousState)
        {
            AimStateChanged?.Invoke(currentState);
            _previousState = currentState;
        }

        if (currentState)
        {
            _camera.fieldOfView = _aimFov;
            _camera.transform.localPosition = _aimCameraPosition;
        }
        else
        {
            _camera.fieldOfView = _defaultFov;
            _camera.transform.localPosition = _defaultCameraPosition;
        }
    }

    private void HandleWeaponChanged(Weapon weapon)
    {
        _canAim = weapon is Pistol;
    }

    [Inject]
    private void Construct(IWeaponInput weaponInput, IWeaponSelectionNotifier weaponSelection)
    {
        _weaponInput = weaponInput;
        _notifier = weaponSelection;
    }
}