using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    private GameObject _target;

    private float _moveSpeed = 5;
    private float _speedIncrease = 0.2f;
    private float _maxSpeed = 15;
    private float _speedIncreaseDelay = 0.5f;
    
    private float _minDistance = 2.5f;

    private float _dashMovement = .5f;
    private float _minDisForDash = 10;
    private float _maxDisForDash = 15;
    

	[SerializeField]private float playerDistance;

	void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");

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
		transform.LookAt (_target.transform.position);

		playerDistance = Vector3.Distance(transform.position, _target.transform.position);

		//when distance is bigger than
		if (playerDistance >= _minDistance)
        {
			//move to target
			transform.position += transform.forward * _moveSpeed * Time.deltaTime;//moves over time
		}

        if (playerDistance <= _maxDisForDash && playerDistance > _minDisForDash)
        {
            DashToPlayer();
		}
    }

    //speed increase over time
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
        transform.position += transform.forward * _dashMovement;// moves over frames
        //transform.position += transform.forward * _maxSpeed * Time.deltaTime;
    }
}
