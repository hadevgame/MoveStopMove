using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public float minDistance = 5f;  
    public float maxDistance = 10f; 
    public float moveSpeed = 2f;    
    private Vector3 startPosition;  
    private Vector3 targetPosition;
    private bool move = false;
    public bool isDead = false;
    void Start()
    {
        startPosition = transform.position;
        // Tạo ra hướng di chuyển và khoảng cách ngẫu nhiên
        SetRandomTargetPosition();
    }
    void Update()
    {
        if(isDead == false) 
        {
            MoveEnemy();
        }
        else StartCoroutine(DeadDelayed());
        
    }
    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-1f, 1f); // Ngẫu nhiên theo trục X
        float randomZ = Random.Range(-1f, 1f); // Ngẫu nhiên theo trục Z
        Vector3 randomDirection = new Vector3(randomX, 0f, randomZ).normalized;
        float randomDistance = Random.Range(minDistance, maxDistance); 
        targetPosition = startPosition + randomDirection.normalized * randomDistance;
        //move = false;
    }
    void MoveEnemy()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.1f && move == false)
        {
            animator.SetBool("IsIdle", false);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            Vector3 direction = targetPosition - transform.position;
            Vector3 directionNoY = new Vector3(direction.x, 0, direction.z);
            transform.rotation = Quaternion.LookRotation(directionNoY);
        }
        else 
        {
            move = true;
            animator.SetBool("IsIdle", true);
            SetRandomTargetPosition();
            StartCoroutine(MoveDelayed());
        } 
    }

    private IEnumerator MoveDelayed()
    {
        yield return new WaitForSeconds(5f);
        move = false;
        //SetRandomTargetPosition() ;
    }

    private IEnumerator DeadDelayed()
    {
        Collider collider = this.GetComponent<Collider>();
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        collider.enabled = false;
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
        
    }
}
