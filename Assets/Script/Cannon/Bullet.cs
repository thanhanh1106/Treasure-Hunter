using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float Force;
    [SerializeField] float explosionRange;
    [SerializeField] float explosionForce;
    [SerializeField] GameObject fragments;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.gravityScale = 9.8f;
        rb.drag = 3f;
    }
    private void OnEnable()
    {
        transform.localPosition = new Vector3(-0.67f, 0.04f, 0);
        rb.AddForce(Vector2.left * Force, ForceMode2D.Impulse);
    }
    private void Update()
    {
        
    }
    void Explode()
    {
        fragments.SetActive(true);
        fragments.transform.position = transform.position;
        fragments.GetComponent<FramgmentsBullet>().SetChild();
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        foreach (Collider2D col in cols)
        {
            Rigidbody2D rbTarget = col.GetComponent<Rigidbody2D>();
            ApplyExplosionForce(rbTarget);
        }
    }
    void ApplyExplosionForce(Rigidbody2D rbTarget)
    {
        Vector3 direction = rbTarget.position - rb.position;
        float distance = direction.magnitude;
        if (distance < explosionForce)
        {
            float forceMagnitude = (1 - distance/explosionRange) * explosionForce; 
            Vector3 force = forceMagnitude* direction.normalized;
            rbTarget.AddForce(force,ForceMode2D.Impulse);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Explode();
    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, explosionRange);
    }
}
