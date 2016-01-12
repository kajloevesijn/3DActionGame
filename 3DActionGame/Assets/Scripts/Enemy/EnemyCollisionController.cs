using UnityEngine;
using System.Collections;

public class EnemyCollisionController : MonoBehaviour {

    private EnemyHealthController _enemyHealth;

	void Start ()
    {
        _enemyHealth = GetComponent<EnemyHealthController>();
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Bullet") {
            _enemyHealth.TakeDamage();
		} 
	}
	//Private Functions
	
	
	//Public Functions
}
