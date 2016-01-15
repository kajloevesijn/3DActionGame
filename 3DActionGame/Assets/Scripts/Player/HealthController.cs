using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour
{
    private float _endGameDelay = 5f;

	[SerializeField]protected ParticleSystem deathParticles;

    [SerializeField]protected int healthPoints = 10;
    public void TakeDamage()
    {
        healthPoints--;
		if (healthPoints <= 0) {
			Instantiate(deathParticles,transform.position,Quaternion.identity);
			Destroy(this.gameObject);
            StartCoroutine(GoToMenu());
		}
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(_endGameDelay);

        Application.LoadLevel(0);
    }

    public int GetHealth()
    {
        return healthPoints;
    }
}
