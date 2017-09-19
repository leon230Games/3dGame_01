using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Controller : MonoBehaviour {

    public static CharacterController characterController;

    #region Singleton
    public static TP_Controller instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Instance of EquipmentManager already exists");
            return;
        }

        instance = this;

        characterController = GetComponent<CharacterController>();
    }
    #endregion

	

	void Update () {

        if (Camera.main == null)
            return;

        GetLocomotionInput();

        TP_Motor.instance.UpdateMotor();
	}

    void GetLocomotionInput()
    {
        var deadZone = 0.1f;

        TP_Motor.instance.moveVector = Vector3.zero;

        if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
        {
            TP_Motor.instance.moveVector += new Vector3(0, 0, Input.GetAxis("Vertical"));
        }

        if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
        {
            TP_Motor.instance.moveVector += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        }
    }
}
