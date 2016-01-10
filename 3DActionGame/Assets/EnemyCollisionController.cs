using UnityEngine;
using System.Collections;

public class EnemyCollisionController : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet") {
			GetComponent<HealthController>().TakeDamage();

		}
	}
	
	//Private Functions
	
	
	//Public Functions
}
