using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public float PlayerHP = 100;
	public float PlayerAmmo1 = 20;
	public float PlayerAmmo2 = 5;
	public float PlayerAmmo3 = 1;
	public float PlayerAmmo4 = 200;
	public int AmmoSelection = 0;
	public GameObject GameOverSprite;
	public bool GameOver = false;
	public GameObject EquipSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((PlayerHP <= 0) && (GameOver == false))	{
			PlayerHP = 0;
			GameOver = true;
			GameOverSprite.SetActive(true);
		}
    }
}
