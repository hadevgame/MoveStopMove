using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    private PlayerAttack playerAttack;
    //private Collider closestEnemy = null;
    //private float closestDistance = Mathf.Infinity;
    private DisplayTargetPoint targetPoint ;
    void Start()
    {
        targetPoint = DisplayTargetPoint.instance;
        playerAttack = PlayerAttack.instance;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetPoint.SetTargetPosition(other.gameObject);
            if (playerAttack.cooldown <= 0)
            {
                playerAttack.Attack(other);
                //float distanceToEnemy = Vector3.Distance(transform.position, other.transform.position);
                // Kiểm tra và cập nhật kẻ địch gần nhất
                //UpdateClosestEnemy(other, distanceToEnemy);
            }
        }
        if (other.CompareTag("map"))
        {
            MapManager mapManager = other.GetComponent<MapManager>();
            mapManager.SetToTransparent();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")) 
        {
            targetPoint.SetOffTarget();
        }
        if (other.CompareTag("map"))
        {
            MapManager mapManager = other.GetComponent<MapManager>();
            mapManager.SetToDeFault();
        }
    }

    
}
