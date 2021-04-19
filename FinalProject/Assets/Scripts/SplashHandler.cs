using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashHandler : MonoBehaviour
{
    [SerializeField] int DelayInSeconds = 5;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(DelayInSeconds);
        FindObjectOfType<LevelLoader>().LoadGameScene();
    }
}
