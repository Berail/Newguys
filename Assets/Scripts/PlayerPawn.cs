using UnityEngine;
using System.Collections;

public class PlayerPawn : MonoBehaviour
{
    [SerializeField] 
    private float rollingSpeed;

    private InputWrapper input;

    [SerializeField]
    private bool inertiaDampersOn = true;

    private Rigidbody pRigidbody;
    
    //Rolling movement parameters
    private float angularDrag;
    private float drag;

    [SerializeField]
    private Vector3 rotationForce; //thrusters
    private Vector3 rotationAxis = Vector3.zero;

    #region MonoBehaviour
    // Use this for initialization
	void Start ()
	{
	    input = InputWrapper.Instance;
	    pRigidbody = gameObject.GetComponent<Rigidbody>();

	    angularDrag = pRigidbody.angularDrag;
	    drag = pRigidbody.drag;

	    UpdateInertiaDampers();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    HandleInput();
	}
    #endregion

    private void HandleInput()
    {
        rotationAxis.x = 0;
        rotationAxis.y = 0;
        rotationAxis.z = 0;

        pRigidbody.AddForce(transform.right * input.RightAxis + 
                            transform.forward * input.ForwardAxis +
                            transform.up * input.UpAxis);

        rotationAxis.x += input.RollForward * rotationForce.x;
        rotationAxis.y += input.RotateRight * rotationForce.y;
        rotationAxis.z += input.RollRight * rotationForce.z;

        if (rotationAxis.magnitude > 0)
        {
            pRigidbody.AddTorque((this.transform.rotation * rotationAxis));
        }
            
        
        
        if (input.ToogleDampers)
        {
            inertiaDampersOn = !inertiaDampersOn;
            UpdateInertiaDampers();
        }
       
    }

    private void UpdateInertiaDampers()
    {
        if (inertiaDampersOn)
        {
            pRigidbody.angularDrag = angularDrag;
            pRigidbody.drag = drag;
        }
        else
        {
            pRigidbody.angularDrag = 0;
            pRigidbody.drag = 0;
        }
    }
}
