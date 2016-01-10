using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{

    [SerializeField]private int healthPoints = 10;

    public void TakeDamage()
    {
        healthPoints--;//replace numbers with variables
		if (healthPoints <= 0) {
			this.gameObject.SetActive(false);
		}
    }
}
