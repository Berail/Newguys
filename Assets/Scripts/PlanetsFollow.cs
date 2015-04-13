using UnityEngine;
using System.Collections;

public class PlanetsFollow : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField] private Transform target;

	// Use this for initialization
	void Start ()
	{
	    offset = this.transform.position - target.localPosition;
	}
	
	// Update is called once per frame
	void Update ()
	{
        this.transform.position = target.localPosition + offset;
	}
}
