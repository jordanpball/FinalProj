using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public void DealDamage(int damage)
    {
        var currentHealth = GetComponent<Slider>().value;
        var newHealth = currentHealth - damage;
      
        if (newHealth > 0)
        {
            GetComponent<Slider>().value = newHealth;
        }
        else
        {
            FindObjectOfType<LevelLoader>().LoadLoseScreen();
        }
    }
}
