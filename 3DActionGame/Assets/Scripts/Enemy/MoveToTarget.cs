using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    private GameObject _target;

    private float _moveSpeed = 5;
    private float _minDistance = 2.5f;

	[SerializeField]private float playerDistance;

	void Start(){

	}

    void Update()
    {
		if (_target != null) {
			transform.LookAt (_target.transform.position);

			playerDistance = Vector3.Distance(transform.position, _target.transform.position);

			//when distance is bigger than
			if (playerDistance >= _minDistance) {
				//move to target
				transform.position += transform.forward * _moveSpeed * Time.deltaTime;
			}else{
				//attack here
			}

		} else {
			_target = GameObject.FindGameObjectWithTag("Player");
		}
    }
}
