using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeRoom : MonoBehaviour
{
	public int sceneNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	public void newRoom() {
		SceneManager.LoadScene(sceneNumber);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
