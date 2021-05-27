using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePalm : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // DEMO PURPOSES ONLY
        wristPitchAngle = 0;
        wristRollAngle = 0;


        //wristPose = new Quaternion();
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*
        if (Input.GetKey(KeyCode.UpArrow) && wristPitchAngle < 89.0f)
        {
            wristPitchAngle += 0.2f;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && wristPitchAngle > -89.0f)
        {
            wristPitchAngle -= 0.2f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && wristRollAngle < 179.0f)
        {
            wristRollAngle += 0.2f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && wristRollAngle > 1.0f)
        {
            wristRollAngle -= 0.2f;
        }

        Quaternion rotation = transform.localRotation;

        rotation.eulerAngles = new Vector3(wristPitchAngle, wristRollAngle, rotation.eulerAngles.z);

        transform.localRotation = rotation;
        */
        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] wristList = dataList[1].Split(';');
        string[] wristRotationData = wristList[0].Split(',');
        string[] wristLocationData = wristList[1].Split(',');

        wristPose.x = int.Parse(wristRotationData[0]) / 1000.0f;
        wristPose.y = int.Parse(wristRotationData[1]) / 1000.0f;
        wristPose.z = int.Parse(wristRotationData[2]) / 1000.0f;
        wristPose.w = int.Parse(wristRotationData[3]) / 1000.0f;

        wristLoc.x = int.Parse(wristLocationData[0]) / 1000.0f;
        wristLoc.y = int.Parse(wristLocationData[1]) / 1000.0f;
        wristLoc.z = int.Parse(wristLocationData[2]) / 1000.0f;

        transform.localRotation = wristPose;
        //transform.localPosition = wristLoc; // if enabled, this moves the wrist to the origin, seperate from the forearm
    }

    // DEMO PURPOSES ONLY
    public float wristPitchAngle;
    public float wristRollAngle;

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE

    public SerialComm serialComm;

    public Quaternion wristPose;
    public Vector3 wristLoc;
}
