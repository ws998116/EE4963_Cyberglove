using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePinky : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PERMANENT CODE
        pinkyFlexScaled = 0;
        pinkyAngle = 0;

        pinky1 = gameObject;
        pinky2 = gameObject.transform.GetChild(0).gameObject;
        pinky3 = pinky2.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*if (Input.GetKey(KeyCode.R) && pinkyAngle < 0.0f)
        {
            pinkyFlexScaled += 0.002f;
        }
        else if (Input.GetKey(KeyCode.F) && pinkyAngle > -89.0f)
        {
            pinkyFlexScaled -= 0.002f;
        }*/

        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] flexData = dataList[0].Split(',');

        pinkyFlexScaled = int.Parse(flexData[4]) / 1000.0f;
        pinkyAngle = pinkyFlexScaled * -90.0f;

        Quaternion rotation1 = pinky1.transform.localRotation;
        Quaternion rotation2 = pinky2.transform.localRotation;
        Quaternion rotation3 = pinky3.transform.localRotation;
        rotation1.eulerAngles = new Vector3(pinkyAngle, rotation1.eulerAngles.y, rotation1.eulerAngles.z);
        rotation2.eulerAngles = new Vector3(pinkyAngle, rotation2.eulerAngles.y, rotation2.eulerAngles.z);
        rotation3.eulerAngles = new Vector3(pinkyAngle, rotation3.eulerAngles.y, rotation3.eulerAngles.z);

        pinky1.transform.localRotation = rotation1;
        pinky2.transform.localRotation = rotation2;
        pinky3.transform.localRotation = rotation3;
    }

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE
    public SerialComm serialComm;

    public float pinkyFlexScaled;
    public float pinkyAngle;

    public GameObject pinky1;
    public GameObject pinky2;
    public GameObject pinky3;
}
