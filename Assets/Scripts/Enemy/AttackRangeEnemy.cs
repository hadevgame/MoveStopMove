using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackRangeEnemy : MonoBehaviour
{
    
    private EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    void Start()
    {
        enemyMovement = EnemyMovement.instance;
       
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy")) 
        {
            enemyMovement.canMove = false;
            enemyAttack.Attack(other);
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
