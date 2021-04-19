using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Level Time in Seconds")]
    [SerializeField] float levelTime = 60f;

    private void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        if (GetComponent<Slider>().value <= levelTime / 2)
        {
            EnemySpawner spawner = FindObjectOfType<EnemySpawner>();
            spawner.SetMaxDelay(3);
        }
        bool timeFinished = (Time.timeSinceLevelLoad >= levelTime);

        if (timeFinished)
        {
            Attacker[] attackers = FindObjectsOfType<Attacker>();
            if(attackers.Length <= 0)
            {
                FindObjectOfType<LevelLoader>().LoadWinScene();
            }
        }
    }
}
