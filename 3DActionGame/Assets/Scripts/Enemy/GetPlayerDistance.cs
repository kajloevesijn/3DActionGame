using UnityEngine;
using System.Collections;

public class GetPlayerDistance : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    public float playerDistance;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetPlayerDist()
    {
        playerDistance = Vector3.Distance(transform.position, _player.transform.position);
        return playerDistance;
    }
}
