using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class Gun : MonoBehaviour
{
    private Animator gunAnimator;
    private AudioSource audioSource;
    public AudioClip shootAudio;
    public AudioClip reloadAudio;
    public AudioClip foleyAudio;
    public AudioClip noAmmoAudio;
    public XRBaseInteractor xrSocketInteractor;
    public ParticleSystem muzzleParticle;
    public Transform muzzlePoint;
    public Transform ejectPoint;
    public Object bulletPrefab;
    public Object shellPrefab;
    public Magazine currentMagazine;
    public Text ammoText;
    private bool allowShooting;
    // Start is called before the first frame update
    void Start()
    {
        // CreateMagazine();
        allowShooting = false;
        gunAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        muzzleParticle.Stop();
        xrSocketInteractor.selectEntered.AddListener(AddMagazine);
        xrSocketInteractor.selectExited.AddListener(RemoveMagazine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void PullTrigger()
    {
        if (currentMagazine && currentMagazine.currentAmmo > 0 && allowShooting)
        {
            gunAnimator.Play("Shoot");
        }
        else
        {
            gunAnimator.Play("Trigger");
            audioSource.PlayOneShot(noAmmoAudio);
        }
    }

    public void Fire()
    {
        currentMagazine.currentAmmo--;
        ammoText.text = currentMagazine.currentAmmo + "/" + currentMagazine.fullAmmo;
        currentMagazine.AmmoReduce();
        audioSource.clip = shootAudio;
        audioSource.Play();
        muzzleParticle.Play();
        CreateBullet();
    }

    private void CreateBullet()
    {
        Instantiate(shellPrefab, ejectPoint.position, ejectPoint.rotation);
        Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
    }

    
    public void AddMagazine(SelectEnterEventArgs selectEnterEventArgs)
    {
        ammoText.text = "Reload!";
        audioSource.PlayOneShot(foleyAudio);
        currentMagazine=selectEnterEventArgs.interactableObject.transform.GetComponent<Magazine>();
        selectEnterEventArgs.interactableObject.transform.GetComponent<Magazine>().insideGun = true;
        allowShooting = false;
    }

    public void RemoveMagazine(SelectExitEventArgs selectExitEventArgs)
    {
        selectExitEventArgs.interactableObject.transform.GetComponent<Magazine>().insideGun = false;
        currentMagazine = null;
        allowShooting = false;
    }

    public void Reload()
    {
        audioSource.PlayOneShot(reloadAudio);
        if (currentMagazine!=null)
        {
            ammoText.text = currentMagazine.currentAmmo + "/" + currentMagazine.fullAmmo;
            allowShooting = true;
        }
    }
}
