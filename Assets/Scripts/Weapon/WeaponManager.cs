using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Rigidbody rb;
    private WeaponPool pool;
    private SpawnWP spawn;
    private PointManager pointManager;
    private DisplayTargetPoint displayTargetPoint;
    private Vector3 startPosition;
    private PlayerAttack player;
    private void Start()
    {
        player = PlayerAttack.instance;
        pool = WeaponPool.instance;
        spawn = SpawnWP.instance;
        pointManager = PointManager.instance;
        
    }
    private void Update()
    {
        if(startPosition!= null) 
        {
            if(Vector3.Distance(startPosition,transform.position) >= 4 * player.transform.localScale.x) 
            {
                pool.ReturnToPool(this.gameObject);
                spawn.Spawn();
            }
        }
    }
    public void MoveToTarget(Vector3 direction) 
    {
        startPosition = transform.position;
        this.transform.parent = null;
        rb.isKinematic = false;
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
        rb.velocity = direction.normalized * 8;
        rb.angularVelocity = new Vector3(0, 100, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        { 
            EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
            Animator objectAnim = other.gameObject.GetComponent<Animator>();
            objectAnim.SetBool("IsDead", true);
            enemyMovement.isDead = true;
            pool.ReturnToPool(this.gameObject);
            spawn.Spawn();
            pointManager.UpdatePoint();
        }
        
    }
    private IEnumerator ReturnWeaponToPoolDelayed()
    {
        yield return new WaitForSeconds(10f);
        pool.ReturnToPool(this.gameObject);
    }
}
