using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    [SerializeField] Defender[] Defenders;

    void Update()
    {
        HandleActivation();
    }

    private void HandleActivation()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateDefender(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ActivateDefender(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ActivateDefender(3);
        }
    }

    private void ActivateDefender(int num)
    {
        int desiredIndex = num - 1;
        foreach (Defender defender in Defenders)
        {
            if (defender == Defenders[desiredIndex])
            {
                Defenders[desiredIndex].Activate();
            }
            else
            {
                defender.Deactivate();
            }
        }
    }
}
