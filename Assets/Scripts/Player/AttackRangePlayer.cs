using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    public PlayerAttack playerAttack;
    private DisplayTargetPoint targetPoint ;
    void Start()
    {
        targetPoint = DisplayTargetPoint.instance;
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            targetPoint.SetOffTarget();
            targetPoint.SetTargetPosition(other.gameObject);
            if (playerAttack.cooldown <= 0)
            {
                playerAttack.Attack(other);
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
