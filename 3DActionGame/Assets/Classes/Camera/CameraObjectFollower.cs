using UnityEngine;
using System.Collections;

public class CameraObjectFollower : MonoBehaviour {
    [SerializeField]private Transform target;
    [SerializeField]private float dampeningSpeed;
    public float cameraHeight; // should be zoomed in if player is in a corridor for le epic effect;

    private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (target)
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
            Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            destination.y = cameraHeight;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampeningSpeed);
        }
	
	}
}
