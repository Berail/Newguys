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
    private bool grabInit, grabUpdate;
    private Vector [] startingHandposition, startingHandNormal, startingHandDirection;


	// Use this for initialization
	void Start () {
        if (controller.IsConnected)
        {
            controller = new Controller();
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

        }
	
	}
}
