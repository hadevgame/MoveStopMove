using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public WeaponManager weaponManager;
    Vector3 direction;
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
            cooldown = 3f;
            enemyMovement.canAttack = false;
            Vector3 targetPos = other.transform.position;
            direction = targetPos - this.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            this.animator.SetBool("IsAttack", true);
            //weaponManager.MoveToTarget(direction);
        }
        
    }
    public void MoveWeaponToTarget()
    {
        weaponManager.MoveToTarget(direction);
    }
}
