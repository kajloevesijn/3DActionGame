using UnityEngine;
using System.Collections;

public class RandomSpawnPoint : MonoBehaviour {

    //around the x and z axis
	Vector3 CreateRandomSpawnPointAroundObject(Vector3 centerPos, float radius)
    {
        float angle = Random.value * 360;

        Vector3 randomPos;

        randomPos.x = centerPos.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        randomPos.y = centerPos.y;
        randomPos.z = centerPos.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);

        return randomPos;
    }
}
