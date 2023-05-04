using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rapidFlip : MonoBehaviour

{
	public GameObject thisOne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
        thisOne.transform.localScale = new Vector3(thisOne.transform.localScale.x, thisOne.transform.localScale.y, thisOne.transform.localScale.z * -1);
    }
}
