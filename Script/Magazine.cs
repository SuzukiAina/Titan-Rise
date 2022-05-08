using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using EPOOutline;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Magazine : MonoBehaviour
{
    public int currentAmmo;
    public int fullAmmo;
    public bool insideGun;

    public List<GameObject> bulletSprite;
    public UnityEvent AmmoGoZero;

    private Animator magazineAnimator;

    private Outlinable outlinable;
    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = fullAmmo;
        magazineAnimator = GetComponent<Animator>();
        outlinable = GetComponent<Outlinable>();
        outlinable.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!insideGun && currentAmmo == 0)
        {
            AmmoGoZero.Invoke();
        }
    }

    public void AmmoReduce()
    {
        bulletSprite[currentAmmo].GetComponent<Image>().enabled = false;
    }

    public void Dissolve()
    {
        magazineAnimator.Play("MagazineDissolve");
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
