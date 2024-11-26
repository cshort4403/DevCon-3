using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    //Determine what keys are being pressed.
    [Header("Inputs")]
    public bool Forward;
    public bool TurnLeft;
    public bool TurnRight;
	public bool Stop;
    public bool Shoot;
    public bool AngleUp;
	public bool AngleDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            //Exit game on escape press
            Application.Quit();
        }

        //4 directional movement with arrow keys or WASD
        Forward = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        Stop = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        TurnLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        TurnRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        //
        Shoot = Input.GetKeyDown(KeyCode.Space);

        AngleUp = Input.GetKey(KeyCode.Z) || Input.GetMouseButtonDown(0);
        AngleDown = Input.GetKey(KeyCode.X) || Input.GetMouseButtonDown(1);

	}
}
