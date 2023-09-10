using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public Transform attackPoint;
    public float attackRange = 3f;
    public LayerMask enemyLayers;

    private int damageAmount = 1;

    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    public int scoreAmount = 1;
    Score score;

    private Shake camShake;

    [SerializeField] private float splitBulletSpeed = 5f;

    [SerializeField] private GameObject firstSplitSprite;
    [SerializeField] private GameObject secondSplitSprite;

    private void Start()
    {
        camShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
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
            camShake.ShakeCamera();
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Health>().Damage(damageAmount);
            score.AddScore(scoreAmount);

            // Instantiate Two half bullets 
            GameObject firsthalf = Instantiate(firstSplitSprite, enemy.transform.position, transform.rotation);
            GameObject secondHalf = Instantiate(secondSplitSprite, enemy.transform.position, transform.rotation);

            float randX = Random.Range(-0.9f, -1.2f);
            float randX1 = Random.Range(-1f, -1.4f);

            float randY = Random.Range(0.95f, 1f);
            float randY1 = Random.Range(-0.99f, -1.5f);

            firsthalf.GetComponent<Rigidbody2D>().velocity = new Vector2(randX, randY) * splitBulletSpeed;
            secondHalf.GetComponent<Rigidbody2D>().velocity = new Vector2(randX1, randY1) * splitBulletSpeed;
            // it will be destroyed by a box collider field that destroy every thing
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
