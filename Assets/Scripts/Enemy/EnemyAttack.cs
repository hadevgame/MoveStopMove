using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public WeaponManager weaponManager;
   
    public float cooldown;
    [SerializeField] private Animator animator;
    
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
    public void Attack(Collider other)
    {
        if (enemyMovement.move == false && enemyMovement.canAttack == true)
        {
            cooldown = 2f;
            enemyMovement.canAttack = false;
            Vector3 targetPos = other.transform.position;
            Vector3 direction = targetPos - this.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            this.animator.SetBool("IsAttack", true);
            //weaponManager.MoveToTarget(direction);
        }
        
    }
}
