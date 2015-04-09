using UnityEngine;
using System.Collections;
using Leap;

public class PlayerMovement : MonoBehaviour {

    private Controller controller;
    private Frame frame;
    private HandList hands;
    private Hand firstHand, secondHand;
    private Pointable pointable;
    private Gesture gesture;
    private bool grabInit, grabUpdate, lerpInit;
    private Vector [] startingHandposition, startingHandNormal, startingHandDirection;
    private Vector3 frontRight, frontLeft, startVec1, startVec2, endVec2, endVec1;
    private float progress, currentLerpTime, lerpTime;
    public float speed;
    public GameObject flashlightLeft, flashlightRight;
    
	// Use this for initialization
	void Start () {
        lerpInit = false;
        controller = new Controller();
        lerpTime = 1f;
        if (controller.IsConnected)
        {
            
            frame = controller.Frame();
            hands = frame.Hands;
            firstHand = hands[0];
            secondHand = hands[1];
            gesture = new Gesture();
            pointable = new Pointable();

            startingHandposition = new Vector[2];
            startingHandNormal = new Vector[2];
            startingHandDirection = new Vector[2];
            
            grabInit = false;
            grabUpdate = false;
        }
        
        
	}
	
	// Update is called once per frame
	void Update () {
        

        if(controller.IsConnected)
        {
            
            frame = controller.Frame();
            hands = frame.Hands;
            firstHand = hands[0];
            secondHand = hands[1];


            if(grabInit == true && grabUpdate == false)
            {
                //Init startingpHandPosition, startingHandDirection and startingHandNormal for both hands



                grabUpdate = true;
            }
            //LEAP MOTION CONTROL
            if ((firstHand.GrabStrength > 0.9f && firstHand.GrabStrength <= 1.0f) && (secondHand.GrabStrength > 0.9f && secondHand.GrabStrength <= 1.0f))
            {
                //Init hands position (for calculating distant from it and turining it to velocity and direction)
                grabInit = true;
                if(grabUpdate == true)
                {

                    //Calcutaions for both hands (convert different in position (in Y AND Z) to velocity and direction of player)

                }
                

            }
            else
            {

                //reset grabInit to False
                
                grabInit = false;
                grabUpdate = false;
            }
           

        }
        else
        {
            //GAMEPAD CONTROL
            /*
             * Instrukcja
             * Trzymamy RB i LB żeby zacząć sterowanie
             * Puszczamy i wyhamowujemy lot
             * Gałka prawa Vecrtical to ruch do przodu z obrotem w lewo (ruch jest skierowany dokladnie w przod/lewo)
             * Gałka lewa Vecrtical to samo tylko oobrot w prawo i ruch prawo/przod)
             * Gałka prawa i lewa Horyzontalnie to obrotu roll
             * triggery to obrot w gore lub w dół
             * 
             * Guzik A włącza wyłącza latareczki( tak dodałem dla picu )
             * 
             * Sterowanie jest zrobione z zamysłem że tak będzie wyglądac przy leapmotion tylko oczywiście input będzie inny ( różnice odległości od począkowego połozenia dłoni)

            /*
            Debug.Log("Joy 1 X " + Input.GetAxis("Horizontal"));
            Debug.Log("Joy 2 X " + Input.GetAxis("Horizontal 2"));
            Debug.Log("Joy 1 Y " + Input.GetAxis("Vertical"));
            Debug.Log("Joy 2 Y " + Input.GetAxis("Vertical 2"));
            Debug.Log("Joy 2 LT " + Input.GetAxis("LT"));
            Debug.Log("Joy 2 RT " + Input.GetAxis("RT"));
            Debug.Log("A" + Input.GetButton("ButtonA"));
            Debug.Log("B" + Input.GetButton("ButtonB"));
            Debug.Log("Y" + Input.GetButton("ButtonY"));
            Debug.Log("X" + Input.GetButton("ButtonX"));
            Debug.Log("Start" + Input.GetButton("Start"));
            Debug.Log("Select" + Input.GetButton("Select"));
            Debug.Log("RB" + Input.GetButton("RB"));
            Debug.Log("LB" + Input.GetButton("LB"));
            */

            if (Input.GetButtonDown("ButtonA"))
            {
                if (flashlightLeft.GetComponent<Light>().enabled == true)
                {
                    flashlightLeft.GetComponent<Light>().enabled = false;
                    flashlightRight.GetComponent<Light>().enabled = false;
                }
                else
                {
                    flashlightLeft.GetComponent<Light>().enabled = true;
                    flashlightRight.GetComponent<Light>().enabled = true;
                }
                

            }
            if(Input.GetButton("RB") && Input.GetButton("LB"))
            {
                lerpInit = true;
                frontLeft = Vector3.Normalize(this.transform.forward + (-this.transform.right));
                frontRight = Vector3.Normalize(this.transform.forward + this.transform.right);
               
                this.GetComponent<Rigidbody>().AddForce(frontRight * Input.GetAxis("Vertical 2") * speed);
                this.GetComponent<Rigidbody>().AddForce(frontLeft * Input.GetAxis("Vertical") * speed);
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Input.GetAxis("Vertical 2") * speed);
                this.GetComponent<Rigidbody>().AddTorque(this.transform.up * Input.GetAxis("Vertical") * speed);
                this.GetComponent<Rigidbody>().AddTorque(this.transform.forward * Input.GetAxis("RT") * speed);
                this.GetComponent<Rigidbody>().AddTorque(-this.transform.forward * Input.GetAxis("LT") * speed);
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Input.GetAxis("Horizontal 2") * speed);
                this.GetComponent<Rigidbody>().AddForce(this.transform.forward * Input.GetAxis("Horizontal") * speed);
                this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Input.GetAxis("Horizontal 2") * speed);
                this.GetComponent<Rigidbody>().AddTorque(this.transform.right * Input.GetAxis("Horizontal") * speed);
            }
            else
            {
                if(lerpInit == true)
                {
                    startVec1 = this.GetComponent<Rigidbody>().angularVelocity;
                    startVec2 = this.GetComponent<Rigidbody>().velocity;
                    endVec1 = Vector3.zero;
                    endVec2 = Vector3.zero;
                    currentLerpTime = 0f;

                    lerpInit = false;
                }
                currentLerpTime += Time.deltaTime;
                if(currentLerpTime > lerpTime)
                {
                    currentLerpTime = lerpTime;
                }
                progress = currentLerpTime / lerpTime;
                if (Vector3.Magnitude(this.GetComponent<Rigidbody>().angularVelocity) > 0)
                {
                    
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.Lerp(startVec1, endVec1, progress);
                }
                else
                {
                    this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
                if (Vector3.Magnitude(this.GetComponent<Rigidbody>().velocity) > 0)
                {
                    this.GetComponent<Rigidbody>().velocity = Vector3.Lerp(startVec2, endVec2, progress);
                }
                else
                {
                    this.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
                

            }

        }
	
	}
}
