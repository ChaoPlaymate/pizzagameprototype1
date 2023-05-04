using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
	public int MusicOn = 1;
	public int SFXOn = 1;
	public int UnlockAll = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	public void SavePrefs()
	{
		PlayerPrefs.SetInt("MusicOn", MusicOn);
		PlayerPrefs.SetInt("SFXOn", SFXOn);
		PlayerPrefs.SetInt("UnlockAll", UnlockAll);
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
