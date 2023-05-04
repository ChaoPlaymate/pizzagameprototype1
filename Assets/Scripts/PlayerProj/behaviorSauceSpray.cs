using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorSauceSpray : MonoBehaviour
{
    public float damage = 5;
	public float despawnTimer = 120;
	private float timer;
	public float speed = .5f;
	public bool inverted;
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
		if (inverted == true) {
			gameObject.transform.Translate((Vector3.forward * speed) * -1);
		} else {
			gameObject.transform.Translate(Vector3.forward * speed);
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		
			Destroy(gameObject);
		
	}
}
