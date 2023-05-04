using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorProjectileEnemy : MonoBehaviour
{
	public float speed = .5f;
	public float damage = 3f;
	public GameObject target;
	public GameObject GameManagerObject;
    // Start is called before the first frame update
    void Start()
    {
		gameObject.transform.LookAt(target.transform);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed);
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
