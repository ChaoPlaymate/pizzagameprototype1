using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiUpdate : MonoBehaviour
{
	public Text healthNumber;
	public GameObject ammo1;
	public GameObject ammo2;
	public GameObject ammo3;
	public GameObject ammo4;
	public GameObject GameManagerObject;
	private float UITextHP;
	private float UITextAmmo1;
	private float UITextAmmo2;
	private float UITextAmmo3;
	private float UITextAmmo4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		UITextHP = GameManagerObject.GetComponent<PlayerStats>().PlayerHP;
		UITextAmmo1 = GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo1;
		UITextAmmo2 = GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo2;
		UITextAmmo3 = GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo3;
		UITextAmmo4 = GameManagerObject.GetComponent<PlayerStats>().PlayerAmmo4;
		healthNumber.GetComponent<Text>().text = UITextHP.ToString();
		ammo1.GetComponent<Text>().text = UITextAmmo1.ToString();
		ammo2.GetComponent<Text>().text = UITextAmmo2.ToString();
		ammo3.GetComponent<Text>().text = UITextAmmo3.ToString();
		ammo4.GetComponent<Text>().text = UITextAmmo4.ToString();
    }
}
