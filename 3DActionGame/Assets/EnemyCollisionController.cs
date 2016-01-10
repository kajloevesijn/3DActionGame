using UnityEngine;
using System.Collections;

public class EnemyCollisionController : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet") {
			GetComponent<EnemyHealthController>().TakeDamage();

		}
	}
	
	//Private Functions
	
	
	//Public Functions
}
