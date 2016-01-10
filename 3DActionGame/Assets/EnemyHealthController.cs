using UnityEngine;
using System.Collections;

public class EnemyHealthController : HealthController {
	public void TakeDamage()
	{
		healthPoints--;
		if (healthPoints <= 0) {
			GameObject player = GameObject.FindGameObjectWithTag("Player");
			Instantiate(deathParticles,transform.position,Quaternion.identity);
			player.GetComponent<ComboSystem>().IncreaseCombo();
			this.gameObject.SetActive(false);
		}
	}
	//Private Functions
	
	
	//Public Functions
}
