using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Transform attackPoint;
    public float attackRange = 3f;
    public LayerMask enemyLayers;

    private int damageAmount = 1;

    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;


    Score score;
    public int scoreAmount = 1;
    private void Start()
    {
        score = GetComponent<Score>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Deflect Pose
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    private void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // detect enemy bullets in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Deflect bullets 
        foreach (Collider2D enemy in hitEnemies)
        {
            // BulletFlyAway();
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Health>().Damage(damageAmount);
            score.AddScore(scoreAmount);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
