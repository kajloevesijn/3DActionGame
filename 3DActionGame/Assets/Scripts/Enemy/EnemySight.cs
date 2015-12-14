using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{
    /*[Range(0.1f, 10f)]
    public float radius;        //radius

    [Range(1f, 360f)]
    public float fov = 90;      //field of view - 90 degrees

    public Vector3 direction = Vector3.forward;

    //used to test the field of view
    public Transform testPoint;
    private Vector3 leftLineFOV;
    private Vector3 rightLineFOV;
    private Vector3 

    // Update is called once per frame
    void Update()
    {
        if(testPoint != null)
        {
            rightLineFOV = RotatePointAroundTransform(direction.normalized * radius, -fov / 2);
            leftLineFOV = RotatePointAroundTransform(direction.normalized * radius, fov / 2);
            Debug.Log(InsideFOV(new Vector3(testPoint.position.x, testPoint.position.y, testPoint.position.z)));
        }
    }

    public bool InsideFOV(Vector3 playerPosition)
    {
        float squaredDistance = ( (playerPosition.x - transform.position.x) * (playerPosition.x - transform.position.x)
                                + (playerPosition.y - transform.position.y) * (playerPosition.y - transform.position.y)
                                + (playerPosition.z - transform.position.z) * (playerPosition.z - transform.position.z)
                                );
        Debug.Log(squaredDistance);

        if (radius * radius >= squaredDistance)
        {
            float signLeftLine = (leftLineFOV.x)
        }

        return false;
    }*/
}
