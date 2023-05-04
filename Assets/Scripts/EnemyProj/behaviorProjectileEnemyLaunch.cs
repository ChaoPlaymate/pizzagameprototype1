using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorProjectileEnemyLaunch : MonoBehaviour
{
	public float force = 1f;
	public float damage = 3f;
	public GameObject target;
	public GameObject GameManagerObject;
	private float forceRelative;
	private bool assigned = false;
    // Start is called before the first frame update
    void Start()
    {
		
    }

    // Update is called once per frame
    void Update()
    {
        if (assigned == false) {
			gameObject.transform.LookAt(target.transform);
			gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x-25,gameObject.transform.eulerAngles.y,gameObject.transform.eulerAngles.z);
			gameObject.GetComponent<Rigidbody>().AddRelativeForce(gameObject.transform.forward * force);
			assigned = true;
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "PlayerPlane")
		{
			if (GameManagerObject.GetComponent<PlayerStats>().GameOver == false) {
			GameManagerObject.GetComponent<PlayerStats>().PlayerHP = GameManagerObject.GetComponent<PlayerStats>().PlayerHP - damage;
			}
			Destroy(gameObject);
			
		}
		if (collision.gameObject.tag == "Projectile")
		{
			Destroy(gameObject);
		}
	}
}
