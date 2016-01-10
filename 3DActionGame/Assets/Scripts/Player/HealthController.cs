using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{

    [SerializeField]protected int healthPoints = 10;
    public void TakeDamage()
    {
        healthPoints--;
		if (healthPoints <= 0) {
			this.gameObject.SetActive(false);
		}
    }
}
