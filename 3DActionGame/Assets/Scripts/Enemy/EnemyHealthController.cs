using UnityEngine;
using System.Collections;

public class EnemyHealthController : HealthController {
	private GameObject player;

	private void Start(){
		player = GetComponent<FindPlayer> ().playerObject;
	}
	public void TakeDamage()
	{
		healthPoints--;
		if (healthPoints <= 0) {
			Instantiate(deathParticles,transform.position,Quaternion.identity);
			player.GetComponent<ComboSystem>().IncreaseCombo();
			GetComponent<ChildDecoupler>().DeCoupler();
			Destroy(this.gameObject);
		}
	}
	//Private Functions
	
	
	//Public Functions
}
