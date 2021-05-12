using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Weapon Rifle;
    public Camera Camera;
    public FixedJoystick FixedJoystick;
    public Transform SpawnWeaponPoint;
    public float MovementSensitivity = 100f;
    public float MaxDistance;

    private float _xRotation = 0f;

    private void Start()
    {
        Instantiate(Rifle.WeaponPrefab, SpawnWeaponPoint.position, SpawnWeaponPoint.rotation, Camera.transform);
    }


    private void Update()
    {
        float joystickX = FixedJoystick.Direction.x * MovementSensitivity * Time.deltaTime;
        float joystickY = FixedJoystick.Direction.y * MovementSensitivity * Time.deltaTime;

        _xRotation -= joystickY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        Camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * joystickX);
    }

    //Check with Raycast if hit something by pressing shoot
    public void Shoot()
    {

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out var hit, MaxDistance))
        {
            if (hit.transform.CompareTag("Target"))
            {
                hit.transform.gameObject.GetComponent<ShootableTarget>().GetHit();
            }    
        }

    }
}
