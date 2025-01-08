using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum OwnerType
    {
        Player,
        Enemy
    }

    public OwnerType owner;
    
}
