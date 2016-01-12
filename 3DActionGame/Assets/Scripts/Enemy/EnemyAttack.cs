using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackDelay = .2f;

    private Vector3 _minAttackDistance;
    [SerializeField]
    private GameObject _target;

    private bool blabla = true;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(AttackPlayer());
        _target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator AttackPlayer()
    {
        while (true)
        {
            if (blabla)
            {
                yield return new WaitForSeconds(_attackDelay);
            }      
        }
    }
}
