using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    private float m_fInputDeltaVal = 0.1f;
    public BallComponent m_ball;
    public Target m_target;

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }


    private void  HandleInput()
    {
     
        /////////
        ///Move Target
        //////////

        if (Input.GetKey(KeyCode.W))
        {
            //Move Target Up
            m_target.OnMoveUp();
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move Target Down
            m_target.OnMoveDown();
        }

        if (Input.GetKey(KeyCode.A))
        {
            //Move Target Left
            m_target.OnMoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Move Target Right
            m_target.OnMoveRight();
        }


        ////////
        ///Move Ball
        ///////


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Move starting position of the ball Left
            m_ball.OnMoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Move starting position of the ball Right
            m_ball.OnMoveRight();
        }

        if (Input.GetKey(KeyCode.R))
        {
            //Reset position of the ball to 0,0,0 
            m_ball.OnBallReset();
            m_target.OnReset();
        }


        ////////
        //Shoot Ball
        ///////
   
        if (Input.GetMouseButtonDown(0))
        {
            m_ball.LaunchBall();
        }


    }
}
