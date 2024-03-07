using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

   [SerializeField] private float speed = 5;
   [SerializeField] private float initialSpeed = 5;

    
    private float runSpeed = 7;
    private Rigidbody2D rig;
    private Vector2 _direction;
    private bool  _isRunning;
    private bool _isRolling;


    
    

     public Vector2 direction
    {
        get {return _direction;}
        set{_direction = value;}
    }

     public bool isRunning
    {
        get {return _isRunning;}
        set{_isRunning = value;}
    }
      public bool isRolling
    {
        get {return _isRolling;}
        set{_isRolling = value;}
    }





    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        OnRun();
        OnInput();
        OnRolling();
    }

    void FixedUpdate(){
        OnMove();
    }


    #region Movement 

    void OnMove()
    {
      rig.MovePosition(rig.position + _direction*speed *Time.fixedDeltaTime);


    }

    void OnRun()
    {
       if(Input.GetKeyDown(KeyCode.LeftShift))
       {
        speed = runSpeed;
        isRunning = true;
       }

       if(Input.GetKeyUp(KeyCode.LeftShift))
       {
        speed = initialSpeed;
        isRunning = false;
       }

    }

     void OnInput()
    {
      _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    }

    void OnRolling()
    {
        if(Input.GetMouseButtonDown(1))
         {
            speed = runSpeed;
            _isRolling = true;
        }

        if (Input.GetMouseButtonUp(1))
        {
            speed = initialSpeed;
            _isRolling = false;
        }



       
    }







    #endregion

}
