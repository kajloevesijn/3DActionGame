using UnityEngine;
using System.Collections;

public class CameraObjectFollower : MonoBehaviour {
    [SerializeField]private Transform target;
    [SerializeField]private float dampeningSpeed;
    [SerializeField]private float cameraHeight; // should be zoomed in if player is in a corridor for le epic effect;
	[SerializeField]private float horMinClamp;// horizontal clamp values
	[SerializeField]private float horMaxClamp;
	[SerializeField]private float verMinClamp;//vertical clamp values
	[SerializeField]private float verMaxClamp;

    private CorridorCheck check;

    private float modifiedCameraHeight;

    private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
        modifiedCameraHeight = cameraHeight;
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			//point.x = Mathf.Clamp(transform.position.x,minClamp,maxClamp); //stops camera from going out of the "level"
			//point.z = Mathf.Clamp(transform.position.z,minClamp,maxClamp);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            //destination.y = modifiedCameraHeight;
			float xClamp = Mathf.Clamp(destination.x,horMinClamp,horMaxClamp);
			float zClamp = Mathf.Clamp(destination.z,verMinClamp,verMaxClamp);
			Vector3 clampedCameraPos = new Vector3(xClamp,modifiedCameraHeight,zClamp);
            transform.position = Vector3.SmoothDamp(transform.position, clampedCameraPos, ref velocity, dampeningSpeed);
        }
	}
}
