using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalk : MonoBehaviour
{
	private float walk;
	private float ogpos;
	private bool direction;
    // Start is called before the first frame update
    void Start()
    {
        walk = gameObject.transform.position.x;
		ogpos = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
		if (direction == false) {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		if ((direction == false) && (Mathf.Abs(gameObject.transform.position.x - ogpos) >= 60)) {
			direction = true;
		}
		if (direction == true) {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y, gameObject.transform.position.z);
		}
		if ((direction == true) && (Mathf.Abs(gameObject.transform.position.x - ogpos) <= 2)) {
			direction = false;
		}
    }
}
