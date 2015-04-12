using UnityEngine;
using System.Collections;

public class Flashlight : MonoBehaviour
{

    private Light light;
	// Use this for initialization
	void Start ()
	{
	    light = this.GetComponent<Light>();
	    light.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetKeyDown(KeyCode.F))
	    {
	        light.enabled = !light.enabled;
	    }
	}
}
