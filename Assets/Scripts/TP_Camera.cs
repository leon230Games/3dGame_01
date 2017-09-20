using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Camera : MonoBehaviour {

    #region Singleton
    public static TP_Camera instance;

    public Transform targteLookAtMain;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Instance of TP_Camera already exists");
            return;
        }

        instance = this;
    }
    #endregion

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void CreateCamera()
    {
        GameObject tempCamera;
        GameObject targetLookAt;
        TP_Camera myCamera;

        if (Camera.main != null)
        {
            tempCamera = Camera.main.gameObject;
        }
        else
        {
            tempCamera = new GameObject("Main Camera");
            tempCamera.AddComponent<Camera>();
            tempCamera.tag = "MainCamera";
        }

        tempCamera.AddComponent<TP_Camera>();
        myCamera = tempCamera.GetComponent<TP_Camera>();

        targetLookAt = GameObject.Find("targetLookAt");

        if (targetLookAt == null)
        {
            targetLookAt = new GameObject("targetLookAt");
            targetLookAt.transform.position = Vector3.zero;
        }

        myCamera.targteLookAtMain = targetLookAt.transform;
    }
}
