using System.Collections;
using System.Collections.Generic;
using Ultilites;
using UnityEngine;

public class FireState : WeaponState
{
    private D_Weapon weaponData;
    private Transform firePoint;
    private Weapon_1 weapon1;

    public FireState(Transform firePoint, D_Weapon weaponData, Weapon_1 weapon1, Weapon weapon, WeaponStateMachine stateMachine, string animBoolName) : base(weapon, stateMachine, animBoolName)
    {
        this.weaponData = weaponData;
        this.weapon1 = weapon1;
        this.firePoint = firePoint;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        //Fire();
    }

    public override void Enter()
    {
        base.Enter();
        
        Fire();
    }

    private void Fire()
    {
        
            SoundManager.Instance.PlaySFX("GunSound");
            CinemachineShake.Instance.ShakeCamera(1.3f, 0.1f);
            
            GameObject projectile = ObjectPooler.Instance.GetPooledObject(weaponData.bulletPref);
            if (projectile == null) return;

            projectile.transform.position = firePoint.position;
            projectile.GetComponent<TrailRenderer>().Clear();
            projectile.transform.rotation = firePoint.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<Rigidbody2D>().AddForce(firePoint.right * weaponData.fireForce, ForceMode2D.Impulse);
            
            StateMachine.ChangeState(weapon1.LookAtMouseState);
    }
}
