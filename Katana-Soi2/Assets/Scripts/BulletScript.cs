using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletSpeed;
    private Rigidbody2D rb;

    [SerializeField] private Transform ballCenter;
    [SerializeField] private float ballRadius;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        // Check for collisions with AttackRange
        Collider2D[] colliders = Physics2D.OverlapCircleAll(ballCenter.position, ballRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Do something when the ballRadius collides with AttackRange
                // For example, you can call a method or execute custom logic
                collider.GetComponent<PlayerCombat>();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(ballCenter.position, ballRadius);
    }
}
