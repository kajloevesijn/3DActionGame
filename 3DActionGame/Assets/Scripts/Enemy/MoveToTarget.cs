using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    private GameObject _target;

    private float _moveSpeed = 5;
    private float _speedIncrease = 0.1f;
    private float _maxSpeed = 15;
    private float _speedIncreaseDelay = 0.5f;

    private float _minDistance = 2.5f;

    [SerializeField]private float _dashMovement = 1f;
    [SerializeField]private float _minDisForDash = 10;
    [SerializeField]private float _maxDisForDash = 15;
	[SerializeField]private float playerDistance;

	[SerializeField]private float attackDelay;
	[SerializeField]private float attackCooldown;
	private float timeStamp;
	private float attackDelayTimeStamp;

	void Start()
    {
		_target = GetComponent<FindPlayer> ().playerObject;

        if (_moveSpeed < _maxSpeed)
        {
            StartCoroutine(GradualSpeedIncrease());
        }
        else
        {
            _moveSpeed = _maxSpeed;
        }
    }

    void Update()
    {
		if (_target != null) {
			transform.LookAt (_target.transform.position);

			playerDistance = Vector3.Distance (transform.position, _target.transform.position);

			//when distance is bigger than
			if (playerDistance >= _minDistance) {
				//move to target
				attackDelayTimeStamp = Time.time + attackDelay;
				transform.position += transform.forward * _moveSpeed * Time.deltaTime;//moves over time
			} else {
				//attack here
				//Debug.Log("attack");
				if (Time.time >= timeStamp && Time.time >= attackDelayTimeStamp) {
					timeStamp = Time.time + attackCooldown;
					_target.GetComponent<HealthController> ().TakeDamage ();
				}
			}

			if (playerDistance <= _maxDisForDash && playerDistance > _minDisForDash) {
				DashToPlayer ();
			}
		}
    }

    IEnumerator GradualSpeedIncrease()
    {
        while (true)
        {
            _moveSpeed += _speedIncrease;
            yield return new WaitForSeconds(_speedIncreaseDelay);
        }
    }

    void DashToPlayer()
    {
        transform.position += transform.forward * Time.deltaTime * _dashMovement;// moves over frames
        //transform.position += transform.forward * _maxSpeed * Time.deltaTime;
    }
}
