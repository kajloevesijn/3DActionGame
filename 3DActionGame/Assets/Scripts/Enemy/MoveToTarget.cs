using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    private GameObject _target;

    private float _moveSpeed = 5;
    private float _speedIncrease = 0.1f;
    private float _maxSpeed = 15;
    private float _speedIncreaseDelay = 0.5f;
<<<<<<< HEAD
    
    private float _minDistance = 1.99f;
=======
>>>>>>> 81482a4cbfebb95cf66db9d1464229fe7fd76859

    [SerializeField]private float _dashMovement = 1f;
    [SerializeField]private float _minDisForDash = 10;
    [SerializeField]private float _maxDisForDash = 15;

	private PlayerDistance playerDistance;
	void Start()
    {
		playerDistance = GetComponent<PlayerDistance> ();
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
			//when distance is bigger than
			if (playerDistance.playerDistance >= _minDistance) {
				//move to target
				transform.position += transform.forward * _moveSpeed * Time.deltaTime;//moves over time
			}

			if (playerDistance.playerDistance <= _maxDisForDash && playerDistance.playerDistance > _minDisForDash) {
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
