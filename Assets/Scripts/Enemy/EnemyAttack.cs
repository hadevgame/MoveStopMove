using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public EnemyMovement enemyMovement;
    public WeaponManager weaponManager;
    private SpawnWP spawn;
    public static EnemyAttack instance;
    public float cooldown;
    [SerializeField] private Animator animator;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
   
    void Update()
    {
        cooldown -= Time.deltaTime;
    }
    public void Attack(Collider other)
    {
        if (enemyMovement.move == false && enemyMovement.canAttack == true)
        {
            cooldown = 1f;
            Vector3 targetPos = other.transform.position;
            Vector3 direction = targetPos - this.transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            animator.SetBool("IsAttack", true);
            //weaponManager.MoveToTarget(direction);
        }
        
    }
}
