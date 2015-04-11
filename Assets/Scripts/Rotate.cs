using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour
{

    [SerializeField]
    private float angularVelocity; //0.0763943727 realistic value

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.Rotate(transform.up, angularVelocity * Time.deltaTime);
	}
}
