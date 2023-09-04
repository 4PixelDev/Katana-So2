using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Deflect Pose
            Attack();
        }
    }

    private void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");
        // detect bullets 
        // Deflect bullets 
        Debug.Log("Attack");
    }
}
