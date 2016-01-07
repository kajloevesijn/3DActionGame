using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public float healthPoints = 10f;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "name")//replace with tag class stuff
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        healthPoints -= 1;//replace numbers with variables
    }
}
