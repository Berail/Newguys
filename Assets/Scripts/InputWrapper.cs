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
    }

    void Update()
    {
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
            return Input.GetAxisRaw("Vertical");
        }
    }

    public float RightAxis
    {
        get
        {
            return Input.GetAxisRaw("Horizontal");
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
            return 0;
        }
    }
    public bool ToogleDampers
    {
        get
        {
            return Input.GetKeyDown(KeyCode.X);
        }
    }
}