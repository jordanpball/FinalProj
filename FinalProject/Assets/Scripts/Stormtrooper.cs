using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stormtrooper : MonoBehaviour
{
    [SerializeField] int damage = 5;
    
    public int GetDamage()
    {
        return damage;
    }
}
