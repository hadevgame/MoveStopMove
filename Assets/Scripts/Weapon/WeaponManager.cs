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
    private CanvasAliveManager canvasAliveManager;
    private Collider weaponCollider;
    public Collider Collider;
    private void Start()
    {
        weaponCollider = GetComponent<Collider>();
        
        player = PlayerAttack.instance;
        pool = WeaponPool.instance;
        spawn = SpawnWP.instance;
        
        
    }
    private void Update()
    {
        if(startPosition!= null) 
        {
            if(Vector3.Distance(startPosition,transform.position) >= 4.5f * player.transform.localScale.x) 
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
        rb.velocity = direction.normalized * 9;
        rb.angularVelocity = new Vector3(0, 200, 0);
        weaponCollider.enabled = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //string colliderTag = enemyCollider.gameObject.tag;
        if (other.CompareTag("Enemy") ) 
        {
            pointManager = PointManager.instance;
            canvasAliveManager = CanvasAliveManager.instance;
            EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
            Animator objectAnim = other.gameObject.GetComponent<Animator>();
            objectAnim.SetBool("IsDead", true);
            enemyMovement.isDead = true;
            canvasAliveManager.UpdateAlive();
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
