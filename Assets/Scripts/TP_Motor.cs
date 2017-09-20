using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Motor : MonoBehaviour {

    public float moveSpeed = 10f;
    public Vector3 moveVector { get; set; }

    #region Singleton
    public static TP_Motor instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Instance of TP_Motor already exists");
            return;
        }

        instance = this;

    }
    #endregion

    public void UpdateMotor() {

        SnapCharWithCam();
        ProcessMotion();
    }

    void ProcessMotion() {
        //transform moveVector to WorldSpace

        moveVector = transform.TransformDirection(moveVector);

        //Normalize vector if magnitude > 0
        if (moveVector.magnitude > 1)
        {
            moveVector = Vector3.Normalize(moveVector);
        }
        //Multiply moveVector by moveSpeed and delta time
        moveVector *= moveSpeed * Time.deltaTime;
        // move character in worldSpace

        TP_Controller.characterController.Move(moveVector);
    }

    void SnapCharWithCam() {

        if (moveVector.x != 0 || moveVector.z != 0)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles.x,
                Camera.main.transform.eulerAngles.y,
                transform.eulerAngles.z);
        }
    }
}
