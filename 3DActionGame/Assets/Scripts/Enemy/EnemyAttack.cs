using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private float _attackDelay = .2f;

    private Vector3 _minAttackDistance;
    [SerializeField]
    private GameObject _target;

    private HealthController _doDamage;


    // Use this for initialization
    void Start()
    {
        //StartCoroutine(AttackPlayer());
        _target = GameObject.FindGameObjectWithTag("Player");
        HealthController _doDamage = _target.GetComponent<HealthController>();
    }
    
    public IEnumerator AttackPlayer()
    {
        while (true)
        {
            _doDamage.TakeDamage();
            yield return new WaitForSeconds(_attackDelay); 
        }
    }
}
