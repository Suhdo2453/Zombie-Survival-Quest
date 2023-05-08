using System;
using System.Collections;
using System.Collections.Generic;
using Ultilites;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.UIElements;

public class Weapon_gun_01 : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;
    [SerializeField] private float fireRate;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private Sound sound;

    private float _fireRate;

    private Vector2 mousePos;
    private Vector2 aimDir;
    private float aimAngle;
    private Player player;

    private void Start()
    {
        _fireRate = fireRate;
        player = GetComponentInParent<Player>();
        SoundManager.Instance.sfxSounds.Add(sound);
    }

    private void FixedUpdate()
    {
        _fireRate -= Time.fixedDeltaTime;
        mousePos = player.InputHandler.MousePosition;
        aimDir = mousePos - (Vector2)transform.position;
        aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimAngle));
        transform.rotation = rotation;
        Flip();
        Fire();
    }

    private void Flip()
    {
        transform.Rotate(player.FacingDirection == -1 ? 180 : 0, 0, 0);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void Fire()
    {
        if (player.InputHandler.AttackInput && _fireRate <= 0)
        {
            SoundManager.Instance.PlaySFX("GunSound");
            CinemachineShake.Instance.ShakeCamera(1.3f, 0.1f);
            
            _fireRate = fireRate;
            GameObject projectile = ObjectPooler.Instance.GetPooledObject(bulletPref);
            if (projectile == null) return;

            projectile.transform.position = firePoint.position;
            projectile.transform.rotation = firePoint.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
        }
    }
}