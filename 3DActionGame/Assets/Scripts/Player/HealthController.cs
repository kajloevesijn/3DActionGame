using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
	[SerializeField]protected ParticleSystem deathParticles;

    [SerializeField]protected int healthPoints = 10;
    public void TakeDamage()
    {
        healthPoints--;
        Debug.Log(healthPoints);
		if (healthPoints <= 0) {
			Instantiate(deathParticles,transform.position,Quaternion.identity);
			this.gameObject.SetActive(false); //kind of like destroying
		}
    }
}
