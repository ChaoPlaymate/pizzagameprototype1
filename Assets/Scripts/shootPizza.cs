using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPizza : MonoBehaviour
{
	public float force;
	public GameObject PizzaObj;
	private Vector3 aim;
	public Camera cam;
	public float Velocity = 500f;
	public float ShotTimerStart = 30f;
	private float ShotTimer;
	private float waitRelease = 0;
	public GameObject PlayerPlane;
	public bool invertShot = false;
	private int shotSelected = 0;
	private bool isSpraying = false;
	private bool shotSelectInput = false;
	public GameObject UISelectIcon;
	public GameObject Ammo1Shot;
	public GameObject Ammo2Shot;
	public GameObject Ammo3Shot;
	public GameObject Ammo4Shot;
	public GameObject GameManagerObject;
	public GameObject EquipSound;
	public GameObject SpraySound;
    // Start is called before the first frame update
    void Start()
    {
        ShotTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {

		ShotTimer -= 1;
        Vector3 mousePos = Input.mousePosition;
		mousePos += Camera.main.transform.forward * 10f;
		aim = cam.ScreenToWorldPoint(mousePos);
	//	Ray ray = cam.ScreenPointToRay (mousePos);
	//	RaycastHit hit;
	//	if (Physics.Raycast (ray, out hit, 100)) {
	//		
	//	}
	//	aim = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
	if ((GameManagerObject.GetComponent<PlayerStats>().GameOver == false)) {
		// Standard Pizza Shot
		if ((Input.GetKey(KeyCode.Mouse0)) && (ShotTimer<=0) && (waitRelease == 0) )
		{
			GameObject pizzaShot = Instantiate(PizzaObj, cam.transform.position, Quaternion.identity);
			pizzaShot.transform.LookAt(aim);
			Physics.IgnoreCollision(pizzaShot.GetComponent<Collider>(), PlayerPlane.GetComponent<Collider>(), true);
			if (invertShot == true) {
				pizzaShot.GetComponent<Rigidbody>().AddRelativeForce((pizzaShot.transform.forward * Velocity) * -1);
			} else {
				pizzaShot.GetComponent<Rigidbody>().AddRelativeForce(pizzaShot.transform.forward * Velocity);
			}
			ShotTimer = ShotTimerStart;
			waitRelease = 1;
		}
		// Mushroom Wall
		if ((Input.GetKey(KeyCode.Mouse1)) && (waitRelease == 0) && (GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo1 > 0) && (shotSelected == 0) ){
			GameObject mushroomShot = Instantiate(Ammo1Shot, cam.transform.position, Quaternion.identity);
			mushroomShot.transform.LookAt(aim);
			Physics.IgnoreCollision(mushroomShot.GetComponent<Collider>(), PlayerPlane.GetComponent<Collider>(), true);
			if (invertShot == true) {
				mushroomShot.GetComponent<Rigidbody>().AddRelativeForce((mushroomShot.transform.forward * Velocity) * -1);
			} else {
			mushroomShot.GetComponent<Rigidbody>().AddRelativeForce(mushroomShot.transform.forward * Velocity);
			}
			mushroomShot.transform.LookAt(cam.transform);
			mushroomShot.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
			waitRelease = 1;
			GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo1 -= 1;
		}
		// Anchovy Dagger
		if ((Input.GetKey(KeyCode.Mouse1)) && (waitRelease == 0) && (GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo2 > 0) && (shotSelected == 1) ) {
			GameObject anchovyDagger = Instantiate(Ammo2Shot, cam.transform.position, Quaternion.identity);
			anchovyDagger.transform.LookAt(aim);
			Physics.IgnoreCollision(anchovyDagger.GetComponent<Collider>(), PlayerPlane.GetComponent<Collider>(), true);
			if (invertShot == true) {
				anchovyDagger.GetComponent<Rigidbody>().AddRelativeForce((anchovyDagger.transform.forward * (Velocity * 2)) * -1);
			} else {
			anchovyDagger.GetComponent<Rigidbody>().AddRelativeForce(anchovyDagger.transform.forward * (Velocity * 2));
			}
			waitRelease = 1;
			GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo2 -= 1;
		}
		//Pepper Bomb
		if ((Input.GetKey(KeyCode.Mouse1)) && (waitRelease == 0) && (GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo3 > 0) && (shotSelected == 2) ) {
			GameObject pepperBomb = Instantiate(Ammo3Shot, cam.transform.position, Quaternion.identity);
			pepperBomb.transform.LookAt(aim);
			Physics.IgnoreCollision(pepperBomb.GetComponent<Collider>(), PlayerPlane.GetComponent<Collider>(), true);
			if (invertShot) {
				pepperBomb.GetComponent<Rigidbody>().AddRelativeForce((pepperBomb.transform.forward * Velocity) * -1);
		} else {
			pepperBomb.GetComponent<Rigidbody>().AddRelativeForce(pepperBomb.transform.forward * Velocity);
		}
		pepperBomb.transform.LookAt(cam.transform);
			pepperBomb.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
			waitRelease = 1;
			GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo3 -= 1;
		}
		// Sauce Spray
		if ((Input.GetKey(KeyCode.Mouse1)) && (GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo4 > 0) && (shotSelected == 3) ){
			GameObject sauceSpray = Instantiate(Ammo4Shot, cam.transform.position, Quaternion.identity);
			if (invertShot == true)
			{
				sauceSpray.GetComponent<behaviorSauceSpray>().inverted = true;
			}
			sauceSpray.transform.LookAt(aim);
			Physics.IgnoreCollision(sauceSpray.GetComponent<Collider>(), PlayerPlane.GetComponent<Collider>(), true);
			waitRelease = 1;
			if (isSpraying == false) {
				SpraySound.GetComponent<AudioSource>().Play();
			}
			isSpraying = true;
			GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo4 -= 1;
		}
		// Ammo Switch
		if (!Input.GetKey(KeyCode.Mouse0) && (!Input.GetKey(KeyCode.Mouse1))) {
			waitRelease = 0;
			isSpraying = false;
			SpraySound.GetComponent<AudioSource>().Stop();
		}
		if ((Input.GetKey(KeyCode.Alpha1)) && (shotSelected != 0) && (shotSelectInput == false) ){
			shotSelected = 0;
			shotSelectInput = true;
			EquipSound.GetComponent<AudioSource>().Play();
			UISelectIcon.GetComponent<RectTransform>().localPosition = new Vector3(2.7f,68f,0f);
		}
		if ((Input.GetKey(KeyCode.Alpha2)) && (shotSelected != 1) && (shotSelectInput == false)) {
			shotSelected = 1;
			shotSelectInput = true;
			EquipSound.GetComponent<AudioSource>().Play();
			UISelectIcon.GetComponent<RectTransform>().localPosition = new Vector3(2.7f,26f,0f);
		}
		if ((Input.GetKey(KeyCode.Alpha3)) && (shotSelected != 2) && (shotSelectInput == false)) {
			shotSelected = 2;
			shotSelectInput = true;
			EquipSound.GetComponent<AudioSource>().Play();
			UISelectIcon.GetComponent<RectTransform>().localPosition = new Vector3(2.7f,-16f,0f);
		}
		if ((Input.GetKey(KeyCode.Alpha4)) && (shotSelected != 3) && (shotSelectInput == false)) {
			shotSelected = 3;
			shotSelectInput = true;
			EquipSound.GetComponent<AudioSource>().Play();
			UISelectIcon.GetComponent<RectTransform>().localPosition = new Vector3(2.7f,-57f,0f);
		}
		if ((!Input.GetKey(KeyCode.Alpha1)) && (!Input.GetKey(KeyCode.Alpha2)) && (!Input.GetKey(KeyCode.Alpha3)) && (!Input.GetKey(KeyCode.Alpha4))) {
			shotSelectInput = false;
		}
		
    }
	}
	
}
