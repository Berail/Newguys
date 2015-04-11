using UnityEngine;
using System.Collections;

public class FPPCamera : MonoBehaviour {
    private InputWrapper input;
    private Quaternion perFrameCameraRotation;
    private float pitch = 0, yaw = 0;

    [SerializeField] 
    private float rotationSpeed;

	// Use this for initialization
	void Start () {
        input = InputWrapper.Instance;
	}
	
	// Update is called once per frame
	void Update () {
	    HandleInput();
	}

    void HandleInput()
    {
        pitch -= input.MouseAxes.y;
        yaw += input.MouseAxes.x;
        this.transform.localRotation = Quaternion.Euler(pitch, yaw, 0);
    }
}
