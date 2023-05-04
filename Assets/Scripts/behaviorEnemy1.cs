using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviorEnemy1 : MonoBehaviour
{
	public float enemyHealth = 5;
	public float enemyDamage = 0;
	public bool enemyShoot;
	public GameObject enemyShot;
	public float shootTimer = 3;
	private float sTime;
	public GameObject EnemyTarget;
	public GameObject GameManagerObject;
	public GameObject KillEffect;
    // Start is called before the first frame update
    void Start()
    {
		sTime = shootTimer;
	}		

    // Update is called once per frame
    void Update()
    {
		sTime -= Time.deltaTime;
        if (enemyHealth <= 0) {
			GameObject DeathEffect = Instantiate(KillEffect, gameObject.transform.position, Quaternion.identity);
			Destroy(gameObject);

		}
		if ((sTime <= 0) && (enemyShoot == true) && (enemyShot != null) && (EnemyTarget != null)) {
			
			GameObject firedShot = Instantiate(enemyShot, gameObject.transform.position - gameObject.transform.worldToLocalMatrix.MultiplyVector(transform.forward), Quaternion.identity);
			if (firedShot.GetComponent<behaviorProjectileEnemy>() != null) {
			firedShot.GetComponent<behaviorProjectileEnemy>().target = EnemyTarget;
			firedShot.GetComponent<behaviorProjectileEnemy>().GameManagerObject =  GameManagerObject;
			}
			if (firedShot.GetComponent<behaviorProjectileEnemyLaunch>() != null) {
				firedShot.GetComponent<behaviorProjectileEnemyLaunch>().target = EnemyTarget;
				firedShot.GetComponent<behaviorProjectileEnemyLaunch>().GameManagerObject = GameManagerObject;
			}
			sTime = shootTimer;
		}
    }
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Projectile")
		{
			if (collision.gameObject.GetComponent<behaviorPizza1>() != null) {
			enemyHealth -= collision.gameObject.GetComponent<behaviorPizza1>().damage;
			} else if (collision.gameObject.GetComponent<behaviorMushroom>() != null) {
				enemyHealth -= collision.gameObject.GetComponent<behaviorMushroom>().damage;
			} else if (collision.gameObject.GetComponent<behaviorSauceSpray>() != null) {
				enemyHealth -= collision.gameObject.GetComponent<behaviorSauceSpray>().damage;
			} else if (collision.gameObject.GetComponent<behaviorMushroom>() != null) {
				enemyHealth -= collision.gameObject.GetComponent<behaviorMushroom>().damage;
			}
		}
	}
}

