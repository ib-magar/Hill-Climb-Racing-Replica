using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.Search;
using UnityEngine;

public class CarController : MonoBehaviour
{

    [SerializeField] Rigidbody2D _car;
    [SerializeField] WheelJoint2D _frontTire;
    [SerializeField] WheelJoint2D _backTire;

    [Header("Speed variables")]
    [SerializeField] float _carSpeed;
    [SerializeField] float _wheelSpeed;
    [SerializeField] private float _horizontalMovement;

    [SerializeField] float _deaccelerationSpeed;
    //
    private void Start()
    {
        
    }
    private void Update()
    {
        _horizontalMovement = -Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {

        if (_horizontalMovement != 0f)
        { 
        //applying the torque to the car body
        _car.AddTorque(-_horizontalMovement * _carSpeed * Time.fixedDeltaTime);
        //_car.AddForce(_horizontalMovement * _carSpeed * Time.deltaTime*transform.right);
        }

        if (_horizontalMovement != 0f)
        {
            // applying the torque to the tires 
            // the torque directio was working opposite so, reversed the value
           // _frontTire.useMotor = true;
           // _backTire.useMotor = true;

            JointMotor2D motor = new JointMotor2D { motorSpeed = _wheelSpeed * _horizontalMovement, maxMotorTorque = 10000f };
            _frontTire.motor = motor;
            _backTire.motor = motor;

        }
        else
        {

            //JointMotor2D currentMotor = _frontTire.motor;
            float currentMotorSpeed =  _frontTire.motor.motorSpeed;
            JointMotor2D motor=new JointMotor2D { motorSpeed=0};
            if (currentMotorSpeed > 0f)
                motor = new JointMotor2D { motorSpeed = currentMotorSpeed - _deaccelerationSpeed, maxMotorTorque = 10000f };
            else if(currentMotorSpeed<0f)
                motor = new JointMotor2D { motorSpeed = currentMotorSpeed + _deaccelerationSpeed, maxMotorTorque = 10000f };
             
            _frontTire.motor = motor;
            _backTire.motor = motor;
            

           // _frontTire.useMotor = false;
            //_backTire.useMotor = false;
        }

    }
    

}
