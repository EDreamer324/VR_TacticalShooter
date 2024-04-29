using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;
using System;


[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawnPos;
    [SerializeField] private float recoilForce;
    [SerializeField] private float damage;

    private Rigidbody rigidBody;
    private XRGrabInteractable interactibleWeapon;

    protected virtual void Awake()
    {
        interactibleWeapon = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactibleWeapon.selectEntered.AddListener(PickUpWeapon);
        interactibleWeapon.selectExited.AddListener(DropWeapon);
        interactibleWeapon.activated.AddListener(StartShooting);
        interactibleWeapon.deactivated.AddListener(StopShooting);
    }

    private void PickUpWeapon(SelectEnterEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            // Code to handle picking up the weapon
            interactor.GetComponent<MeshHider>().Hide();
        }  
    }

    private void DropWeapon(SelectExitEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            // Code to handle dropping the weapon
            interactor.GetComponent<MeshHider>().Show();
        }  
    }

    protected virtual void StartShooting(ActivateEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            // Code to start shooting with the weapon
        }  
    }

    protected virtual void StopShooting(DeactivateEventArgs args)
    {
        XRBaseInteractor interactor = args.interactorObject as XRBaseInteractor;
        if (interactor != null)
        {
            // Code to stop shooting with the weapon
        }  
    }


    protected virtual void Shoot()
    {
        ApplyRecoil();
    }

    private void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    public float GetShootingForce()
    {
        return shootingForce;
    }

    public float GetDamage()
    {
        return damage;
    }
}
