using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour {

    private float _knockBackRadius = 5;
    private float _knockBackPower = 2500;

    private Vector3 _knockBackPos; //where the knockback needs to take place

    private Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _knockBackPos = transform.position;
    }

	void OnTriggerEnter(Collider other){

		if (other.tag == "Ammo") {
			GetComponent<AmmoController>().playerAmmo += other.gameObject.GetComponent<AmmoBox>().AmmoPickup();
			Debug.Log(GetComponent<AmmoController>().playerAmmo);
		}


        //tested explosionforce and it did not have the wanted outcome
        /*if (other.tag == "Enemy")
        {
            Debug.Log("work1");
            KnockBack();
        }*/
	}

    /*void KnockBack()
    {
        Debug.Log("work2");
        Collider[] colliders = Physics.OverlapSphere(_knockBackPos, _knockBackRadius);
        foreach (Collider hit in colliders)
        {
            Debug.Log("work3");
            rb.AddExplosionForce(_knockBackPower, _knockBackPos, _knockBackRadius, 0f);
        }

    }*/
}
