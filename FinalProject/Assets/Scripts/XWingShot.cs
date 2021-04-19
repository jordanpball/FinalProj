using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XWingShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;
        if (otherObject.GetComponent<ATAT>())
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
