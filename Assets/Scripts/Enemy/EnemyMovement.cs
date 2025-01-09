using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public float minDistance;
    public float maxDistance;
    public float moveSpeed;    
    private Vector3 targetPosition;
    public bool move = true;
    public bool canAttack = true;
    public bool canMove = true;
    public bool isDead = false;
    
    void Start()
    {
        SetRandomTargetPosition();
    }
    void Update()
    {
        if (isDead == false )
        {
            MoveEnemy();
        }
        else 
        {
            StartCoroutine(DeadDelayed());
        }
    }
    public void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-1f, 1f); // Ngẫu nhiên theo trục X
        float randomZ = Random.Range(-1f, 1f); // Ngẫu nhiên theo trục Z
        Vector3 randomDirection = new Vector3(randomX, 0f, randomZ);
        float randomDistance = Random.Range(minDistance, maxDistance); 
        targetPosition = transform.position + randomDirection.normalized * randomDistance;
    }
    void MoveEnemy()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f && canMove == true)
        {
            move = true;
            animator.SetBool("IsIdle", false);
            animator.SetBool("IsAttack", false);
            //transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed  * Time.deltaTime);
            Vector3 direction = targetPosition - transform.position;
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
            Vector3 directionNoY = new Vector3(direction.x, 0, direction.z);
            transform.rotation = Quaternion.LookRotation(directionNoY);
        }
        else 
        {
            animator.SetBool("IsIdle", true);
            move = false;
            canAttack = true;
            canMove = false;
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) 
            {
                SetRandomTargetPosition();
                StartCoroutine(MoveDelayed());
            }
                
        } 
    }
    private IEnumerator MoveDelayed()
    {
        yield return new WaitForSeconds(5f);
        canMove = true;
        //SetRandomTargetPosition() ;
    }
    private IEnumerator DeadDelayed()
    {
        Collider collider = this.GetComponent<Collider>();
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        collider.enabled = false;
        this.enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
        
        //this.gameObject.SetActive(false);
    }
}
