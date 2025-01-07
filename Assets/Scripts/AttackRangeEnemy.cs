using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRangeEnemy : MonoBehaviour
{
    private EnemyAttack enemyAttack;
    private EnemyMovement enemyMovement;
    void Start()
    {
        enemyMovement = EnemyMovement.instance;
        enemyAttack = EnemyAttack.instance;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Player") )
        {
            if (enemyAttack.cooldown <= 0)
            {
                enemyMovement.canMove = false;
                enemyAttack.Attack(other);
            }
            if (enemyMovement.canMove == true && enemyMovement.canAttack == true)
            {
                enemyMovement.canMove = false;
                enemyAttack.Attack(other);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other = null;
            enemyMovement.canMove = true;
            
        }
    }
}
