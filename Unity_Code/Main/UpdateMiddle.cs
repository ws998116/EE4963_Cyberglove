using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMiddle : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PERMANENT CODE
        middleFlexScaled = 0;
        middleAngle = 0;

        middle1 = gameObject;
        middle2 = gameObject.transform.GetChild(0).gameObject;
        middle3 = middle2.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*if (Input.GetKey(KeyCode.R) && middleAngle < 0.0f)
        {
            middleFlexScaled += 0.002f;
        }
        else if (Input.GetKey(KeyCode.F) && middleAngle > -89.0f)
        {
            middleFlexScaled -= 0.002f;
        }*/

        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] flexData = dataList[0].Split(',');

        middleFlexScaled = int.Parse(flexData[2]) / 1000.0f;

        middleAngle = middleFlexScaled * -90.0f;

        Quaternion rotation1 = middle1.transform.localRotation;
        Quaternion rotation2 = middle2.transform.localRotation;
        Quaternion rotation3 = middle3.transform.localRotation;
        rotation1.eulerAngles = new Vector3(middleAngle, rotation1.eulerAngles.y, rotation1.eulerAngles.z);
        rotation2.eulerAngles = new Vector3(middleAngle, rotation2.eulerAngles.y, rotation2.eulerAngles.z);
        rotation3.eulerAngles = new Vector3(middleAngle, rotation3.eulerAngles.y, rotation3.eulerAngles.z);

        middle1.transform.localRotation = rotation1;
        middle2.transform.localRotation = rotation2;
        middle3.transform.localRotation = rotation3;
    }

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE

    public SerialComm serialComm;

    public float middleFlexScaled;
    public float middleAngle;

    public GameObject middle1;
    public GameObject middle2;
    public GameObject middle3;
}
