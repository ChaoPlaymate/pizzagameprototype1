using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextRoomTestButton : MonoBehaviour
{
public GameObject NextEnemyGroup;
public Camera MainCam;
public GameObject NextCamPoint;
private bool CameraMoving = false;
private bool CameraFinish = false;
public float speed = 1.0f;
public bool invert = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Vector3 ErrorMargin = new Vector3(0.2f,0.2f,0.2f);
		float step = speed * Time.deltaTime;
        if ((CameraMoving == true) && (CameraFinish == false)) {
			MainCam.transform.position = Vector3.Lerp(MainCam.transform.position, NextCamPoint.transform.position, step);
			MainCam.transform.eulerAngles = Vector3.Lerp(MainCam.transform.eulerAngles, NextCamPoint.transform.eulerAngles, step);
			if ((MainCam.transform.position.x - NextCamPoint.transform.position.x <= ErrorMargin.x)
			&& (MainCam.transform.position.y - NextCamPoint.transform.position.y <= ErrorMargin.y)
			&& (MainCam.transform.position.z - NextCamPoint.transform.position.z <= ErrorMargin.z))
			{
				MainCam.transform.position = NextCamPoint.transform.position;
			}
			if ((MainCam.transform.position == NextCamPoint.transform.position)
				&& (CameraMoving == true)) {
				CameraMoving = false;
				CameraFinish = true;
				NextEnemyGroup.SetActive(true);
			}
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