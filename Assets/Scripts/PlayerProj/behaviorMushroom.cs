using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorMushroom : MonoBehaviour
{
    public float damage = 5;
	public float despawnTimer = 180;
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
