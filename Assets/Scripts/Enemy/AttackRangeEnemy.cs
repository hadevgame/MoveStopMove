using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRangeEnemy : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy")) 
        {
            enemyMovement.canMove = false;
            if (enemyAttack.cooldown < 0) 
            {
                enemyAttack.Attack(other);
            }
            if (other.CompareTag("map")) 
            {
                enemyMovement.canMove = false;
                enemyMovement.SetRandomTargetPosition();
            }
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if ( other.CompareTag("Player"))
        {
            other = null;
            enemyMovement.canMove = true;
        }
        
    }
}
