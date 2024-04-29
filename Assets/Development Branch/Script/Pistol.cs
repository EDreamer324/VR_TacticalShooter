using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;

    protected override void StartShooting(ActivateEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            base.StartShooting(args);
            Shoot();
        }
    }

    protected override void Shoot()
    {
        base.Shoot();
        Projectile projectileInstantiate = Instantiate(bulletPrefab, bulletSpawnPos.position, bulletSpawnPos.rotation);
        projectileInstantiate.Init(this);
        projectileInstantiate.Launch();
    }

    protected override void StopShooting(DeactivateEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            base.StopShooting(args);
        }  
    }
}
