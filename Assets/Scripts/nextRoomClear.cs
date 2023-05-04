using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRoomClear : MonoBehaviour
{
public GameObject CurrentEnemyGroup;
public GameObject NextEnemyGroup;
public Camera MainCam;
public GameObject NextCamPoint;
public bool CameraMoving = false;
public bool CameraFinish = false;
public float speed = 1.0f;
public bool invert = false;
public float moveDelay = 60f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 ErrorMargin = new Vector3(.1f,.1f,.1f);
		float step = speed * Time.deltaTime;
        if ((CameraMoving == true) && (CameraFinish == false)) {
			MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, NextCamPoint.transform.position, step);
			MainCam.transform.rotation = Quaternion.Lerp(MainCam.transform.rotation, NextCamPoint.transform.rotation, step);
			if ((Mathf.Abs(MainCam.transform.position.x) - Mathf.Abs(this.NextCamPoint.transform.position.x) <= Mathf.Abs(ErrorMargin.x))
			&& (Mathf.Abs(MainCam.transform.position.y) - Mathf.Abs(this.NextCamPoint.transform.position.y) <= Mathf.Abs(ErrorMargin.x))
			&& (Mathf.Abs(MainCam.transform.position.z) - Mathf.Abs(this.NextCamPoint.transform.position.z) <= Mathf.Abs(ErrorMargin.x)))
			{
				MainCam.transform.rotation = this.NextCamPoint.transform.rotation;
				MainCam.transform.position = this.NextCamPoint.transform.position;
				
			}
			if ((MainCam.transform.position == NextCamPoint.transform.position)
				&& (CameraMoving == true)) {
				CameraMoving = false;
				CameraFinish = true;
				if (invert == true) {
					MainCam.GetComponent<shootPizza>().invertShot = true;
				} else {
					MainCam.GetComponent<shootPizza>().invertShot = false;
				}
				if ((NextEnemyGroup != null)) {
				NextEnemyGroup.SetActive(true);
				}
			}
				
			
			}
			if ((CurrentEnemyGroup.gameObject.transform.childCount == 0) && (CameraFinish == false)) {
				moveDelay -= 1;
			}
			if ((moveDelay <= 0)) {
				CameraMoving = true;
			}
   }
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Projectile") {
			Destroy(collision.gameObject);
			CameraMoving = true;
		}
	}
}