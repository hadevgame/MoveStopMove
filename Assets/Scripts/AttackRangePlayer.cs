using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackRangePlayer : MonoBehaviour
{
    private PlayerAttack playerAttack;
    void Start()
    {
        playerAttack = PlayerAttack.instance;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
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
        if (other.CompareTag("map"))
        {
            MapManager mapManager = other.GetComponent<MapManager>();
            mapManager.SetToDeFault();
        }
    }
}
