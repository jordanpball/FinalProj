using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<ATST>())
        {
            otherObject.GetComponent<Animator>().SetTrigger("TriggerDeath");
            DestroyMe();
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
