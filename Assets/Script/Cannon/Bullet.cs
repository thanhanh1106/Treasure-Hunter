using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    Cannon thisCannon;
    [SerializeField] float Force;
    [SerializeField] float explosionRange;
    [SerializeField] float explosionForce;
    [SerializeField] GameObject explosionEffect;
    float countDown;
    float damage = 10f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        thisCannon = rb.GetComponentInParent<Cannon>();
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
        countDown = 0;
    }
    private void Update()
    {
        countDown += Time.deltaTime;
        if(countDown > 2)
            Explode();
    }
    void Explode()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, explosionRange);
        foreach (Collider2D col in cols)
        {
            Rigidbody2D rbTarget = col.GetComponent<Rigidbody2D>();
            ApplyExplosionForce(rbTarget);
            col.GetComponent<IDamageable>()?.TakeDamage(damage); 
        }
        explosionEffect.SetActive(true);
        explosionEffect.transform.position = transform.position;
        thisCannon.IsShooting = false;
        gameObject.SetActive(false);
    }
    void ApplyExplosionForce(Rigidbody2D rbTarget)
    {
        Vector3 direction = rbTarget.position - rb.position;
        float distance = direction.magnitude;
        if (distance < explosionForce)
        {
            float forceMagnitude = (1 - distance/explosionRange) * explosionForce; 
            Debug.Log(forceMagnitude);
            Vector3 force = forceMagnitude* direction.normalized;
            rbTarget.AddForce(force,ForceMode2D.Impulse);
        }

    }
    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(transform.position, explosionRange);
    }
}
