using System;
using UnityEngine;
using Zenject;
//изменение приближения при прицеливании
public class Aiming : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _defaultFov;
    [SerializeField] private float _aimFov;

    [SerializeField] private WeaponSwitcher _weaponSwitcher;

    private IWeaponInput _weaponInput;

    private Vector3 _defaultCameraPosition;
    private Vector3 _aimCameraPosition;

    private bool _previousState;
    private bool _canAim;//могу прицелится?

    public event Action<bool> OnAimStateChanged;

    private void Start()
    {
        _defaultCameraPosition = _camera.transform.localPosition;
        _aimCameraPosition = new Vector3(0.49f, _defaultCameraPosition.y, _defaultCameraPosition.z);
    }

    private void OnEnable()
    {
        _weaponSwitcher.WeaponChanged += Process;
    }

    private void OnDisable()
    {
        _weaponSwitcher.WeaponChanged -= Process;
    }

    private void Update()
    {
        bool currentState = _weaponInput.IsAiming && _canAim;

        if (currentState != _previousState)//текущее состояние отличается от предыдущего?
        {
            OnAimStateChanged?.Invoke(currentState);
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

    private void Process(Weapon weapon)
    {
        if(weapon is Pistol)
        {
            _canAim = true;
            return;
        }

        _canAim = false;
    }

    [Inject]
    private void Construct(IWeaponInput weaponInput)
    {
        _weaponInput = weaponInput;
    }
}