using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorPepperBomb : MonoBehaviour
{
	public float damage = 500f;
	public float explosionTimer = 60f;
	public float explosionLinger = 60f;
	public GameObject explosion;
	private bool hasExploded = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        explosionTimer -= 1;
		
		//Begin Explosion
		if ((explosionTimer <= 0) && (hasExploded == false)) {
			explosion.SetActive(true);
			hasExploded = true;
		}
		if (hasExploded == true) {
			explosionLinger -=1;
		}
		if (explosionLinger <= 0) {
			Destroy(gameObject);
		}
    }
}
