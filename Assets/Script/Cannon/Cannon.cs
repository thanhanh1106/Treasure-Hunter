using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] GameObject fireEffect;
    [SerializeField] GameObject bullet;
    event Action OnFireEvents;

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
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            animator.SetTrigger("Fire");

        }
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
}
