using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideAfterStart : MonoBehaviour
{
    [SerializeField] int SecondsBeforeHiding = 5;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(SecondsBeforeHiding);
        GetComponent<Text>().gameObject.SetActive(false);
    }
}
