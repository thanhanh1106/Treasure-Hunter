using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour,IDamageable
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] GameObject fireEffect;
    [SerializeField] GameObject bullet;
    event Action OnFireEvents;

    [HideInInspector] public bool IsShooting;
    float countDown;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        OnFireEvents += OnTriggerEffect;
        OnFireEvents += OnFireBullet;
    }
    private void Update()
    {
        if (!IsShooting)
            countDown += Time.deltaTime;

        if(countDown > 2)
            Shoot();

    }
    void Shoot()
    {
        animator.SetTrigger("Fire");
        IsShooting = true;
        countDown = 0;
    }
    void OnTriggerEffect()
    {
        fireEffect.SetActive(true);
    }
    void OnFireBullet()
    {
        bullet.SetActive(true);
    }
    void OnTriggerFireEvents()
    {
        OnFireEvents();
    }
    public void TakeDamage(float damage)
    {
        
    }
}
