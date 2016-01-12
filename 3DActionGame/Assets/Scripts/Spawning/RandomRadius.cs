using UnityEngine;
using System.Collections;

public class RandomRadius : MonoBehaviour {

    [SerializeField]
    private float _minimalRadius;
    [SerializeField]
    private float _maximalRadius;

    float CreateRandomRadius()
    {
        float randomRadius;
        randomRadius = Random.Range(
                        -Random.Range(_minimalRadius, _maximalRadius),//random number between negative radiuses
                        Random.Range(_minimalRadius, _maximalRadius)//random number between positive radiuses
                        );
        return randomRadius;
    }
}
