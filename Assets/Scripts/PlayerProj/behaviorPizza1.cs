using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorPizza1 : MonoBehaviour
{
	public float damage = 5;
	public float despawnTimer = 120;
	private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = despawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1;
		if (timer <= 0) {
			Destroy(gameObject);
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}
}
