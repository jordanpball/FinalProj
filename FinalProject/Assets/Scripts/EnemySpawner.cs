using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Attacker[] attackerArray;
    [SerializeField] int minDelayInSec = 1;
    [SerializeField] int maxDelayInSec = 5;

    [SerializeField] float topPadding = 1.8f;
    [SerializeField] float botPadding = 0.5f;


    bool doSpawn = true;

    float yMin;
    float yMax;
    // Start is called before the first frame update

    void Start()
    {
        SetupMoveBoundaries();
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        Debug.Log("Spawn Started");
        while (doSpawn)
        {
            yield return new WaitForSeconds(Random.Range(minDelayInSec, maxDelayInSec));
            Spawn();
        }
    }

    private void SetupMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + botPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - topPadding;
    }

    private void Spawn()
    {
        var attackerIndex = Random.Range(0, attackerArray.Length);
        SpawnAttacker(attackerArray[attackerIndex]);
    }

    private void SpawnAttacker(Attacker attacker)
    {
        var yVal = Random.Range(yMin, yMax);
        var position = new Vector3(transform.position.x, yVal, transform.position.z);
        Attacker newAttacker = Instantiate(attacker, position, transform.rotation);
    }
}
