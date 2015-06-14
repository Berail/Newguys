using UnityEngine;
using System.Collections;

public class InputWrapper : MonoBehaviour
{
    private static InputWrapper _instance;
    private Vector2 mouseAxes = Vector2.zero;

    #region MonoBehaviour
    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Debug.Log(RotateRight);
      
        mouseAxes.x = Input.GetAxis("Mouse X");
        mouseAxes.y = Input.GetAxis("Mouse Y");
    }

    #endregion

    public static InputWrapper Instance
    {
        get
        {
            return _instance;
        }
    }

    public float ForwardAxis
    {
        get
        {
            if (Input.GetAxisRaw("Vertical") != 0)
            {
                return Input.GetAxisRaw("Vertical");
            }
            else if (Input.GetAxis("ThumbLeftVert") != 0)
            {
                return Input.GetAxis("ThumbLeftVert");
            }
            else
                return 0;
           
        }
    }

    public float RightAxis
    {
        get
        {

            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                return Input.GetAxisRaw("Horizontal");
            }
            else if (Input.GetAxis("ThumbLeftHor") != 0)
            {
                return Input.GetAxis("ThumbLeftHor");
            }
            else
                return 0;
            
            
        }
    }

    public float UpAxis
    {
        get
        {
            if (Input.GetKey(KeyCode.Space))
            {
                return 1;
            }
            else if (Input.GetKey(KeyCode.C))
            {
                return -1;
            }
            else if (Input.GetButton("RB"))
            {
                return 1;
            }
            else if (Input.GetButton("LB"))
            {
                return -1;
            }
            return 0;
        }
    }

    public Vector2 MouseAxes
    {
        get
        {
            return mouseAxes;
        }
    }
    
    public float RollRight
    {
        get
        {
            if (Input.GetKey(KeyCode.E))
                return -1;
            else if (Input.GetKey(KeyCode.Q))
                return 1;
            else if (Input.GetAxisRaw("RT") < 0)
            {
                return -1 * Input.GetAxisRaw("RT");
            }
            else if (Input.GetAxisRaw("LT") < 0)
            {
                return Input.GetAxisRaw("LT");
            }
            
            else return 0;
        }
    }

    public float RotateRight
    {
        get
        {
            if (Input.GetKey(KeyCode.RightArrow))
                return 1;
            else if (Input.GetKey(KeyCode.LeftArrow))
                return -1;
            
            else if (Input.GetAxisRaw("ThumbRightHor") != 0)
            {
                return Input.GetAxisRaw("ThumbRightHor");
            }
            else return 0;
        }
    }

    public float RollForward
    {
        get
        {
            if (Input.GetKey(KeyCode.UpArrow))
                return 1;
            else if (Input.GetKey(KeyCode.DownArrow))
                return -1;
            else if (Input.GetAxisRaw("ThumbRightVert") != 0)
            {
                return Input.GetAxisRaw("ThumbRightVert");
            }
            return 0;
        }
    }
    public bool ToogleDampers
    {
        get
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                return true;
            }
            else if (Input.GetButton("ButtonB"))
            {
                return true;
            }
            else
                return false;
        }
    }

   
}