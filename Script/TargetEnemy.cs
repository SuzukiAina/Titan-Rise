using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TargetEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator targetAnimator;
    private AudioSource audioSource;
    public bool hit;
    public UnityEvent hitEvent;

    public GameObject bullet;
    public ParticleSystem muzzlueFlash;
    public Transform bulletSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        targetAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetAnimator != null)
        {
            if (hit)
            {
                targetAnimator.SetTrigger("Dead");
            }
        }
    }

    public void Hitted()
    {
        hit = true;
        hitEvent.Invoke();
    }

    public void EnemySelfDestroy()
    {
        Destroy(this.gameObject);
    }

    public void PullTrigger()
    {
        Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        muzzlueFlash.Play();
        if (audioSource != null)
        { 
            audioSource.Play();
        }
    }
}
