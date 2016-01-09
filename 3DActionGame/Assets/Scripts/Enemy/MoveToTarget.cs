using UnityEngine;
using System.Collections;

public class MoveToTarget : MonoBehaviour
{
    public GameObject _target;

    private float _moveSpeed = 5;
    private float _minDistance = 1;

    void Update()
    {
        transform.LookAt(_target.transform.position);

        //when distance is bigger than
        if (Vector3.Distance(transform.position, _target.transform.position) >= _minDistance)
        {
            //move to target
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;
        }
    }
}
