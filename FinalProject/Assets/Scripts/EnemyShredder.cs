using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShredder : MonoBehaviour
{
    [SerializeField] GameObject HealthSlider;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Attacker>())
        {
            HealthSlider.GetComponent<HealthDisplay>().DealDamage(otherObject.GetComponent<Attacker>().GetDamage());
            Destroy(otherObject);
        }
    }
}
