using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateForearm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // DEMO PURPOSES ONLY
        forearmPitchAngle = 0;
        forearmRollAngle = 0;


        // PERMANENT CODE
        forearmPose = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*
        if (Input.GetKey(KeyCode.UpArrow) && forearmPitchAngle < 89.0f)
        {
            forearmPitchAngle += 0.2f;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && forearmPitchAngle > -89.0f)
        {
            forearmPitchAngle -= 0.2f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && forearmRollAngle < 179.0f)
        {
            forearmRollAngle += 0.2f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && forearmRollAngle > 1.0f)
        {
            forearmRollAngle -= 0.2f;
        }

        Quaternion rotation = transform.localRotation;

        rotation.eulerAngles = new Vector3(forearmPitchAngle, forearmRollAngle, rotation.eulerAngles.z);

        transform.localRotation = rotation;
        */

        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] forearmList = dataList[2].Split(';');
        string[] forearmRotationData = forearmList[0].Split(',');
        string[] forearmLocationData = forearmList[1].Split(',');
        
        forearmPose.x = int.Parse(forearmRotationData[0]) / 1000.0f;
        forearmPose.y = int.Parse(forearmRotationData[1]) / 1000.0f;
        forearmPose.z = int.Parse(forearmRotationData[2]) / 1000.0f;
        forearmPose.w = int.Parse(forearmRotationData[3]) / 1000.0f;

        forearmLoc.x = int.Parse(forearmLocationData[0]) / 1000.0f;
        forearmLoc.y = int.Parse(forearmLocationData[1]) / 1000.0f;
        forearmLoc.z = int.Parse(forearmLocationData[2]) / 1000.0f;

        transform.localRotation = forearmPose;
        transform.localPosition = forearmLoc;
    }

    // DEMO PURPOSES ONLY
    public float forearmPitchAngle;
    public float forearmRollAngle;

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE

    public SerialComm serialComm;

    public Quaternion forearmPose;
    public Vector3 forearmLoc;
}
