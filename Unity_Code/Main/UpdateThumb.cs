using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateThumb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PERMANENT CODE
        thumbFlexScaled = 0;
        thumbAngle = 0;

        thumb1 = gameObject;
        thumb2 = gameObject.transform.GetChild(0).gameObject;
        thumb3 = thumb2.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*if (Input.GetKey(KeyCode.R) && thumbAngle < 0.0f)
        {
            thumbFlexScaled += 0.002f;
        }
        else if (Input.GetKey(KeyCode.F) && thumbAngle > -89.0f)
        {
            thumbFlexScaled -= 0.002f;
        }*/

        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] flexData = dataList[0].Split(',');

        thumbFlexScaled = int.Parse(flexData[0]) / 1000.0f;
        thumbAngle = thumbFlexScaled * -90.0f;
        if (thumbAngle < -89.9f)
        {
            thumbAngle = -89.9f;
        }
        else if (thumbAngle > 0.01f)
        {
            thumbAngle = 0.01f;
        }

        Quaternion rotation1 = thumb1.transform.localRotation;
        Quaternion rotation2 = thumb2.transform.localRotation;
        Quaternion rotation3 = thumb3.transform.localRotation;
        rotation1.eulerAngles = new Vector3(rotation1.eulerAngles.x, thumbAngle / 2.0f, rotation1.eulerAngles.z);
        rotation2.eulerAngles = new Vector3(thumbAngle, rotation2.eulerAngles.y, rotation2.eulerAngles.z);
        rotation3.eulerAngles = new Vector3(thumbAngle, rotation2.eulerAngles.y, rotation3.eulerAngles.z);

        thumb1.transform.localRotation = rotation1;
        thumb2.transform.localRotation = rotation2;
        thumb3.transform.localRotation = rotation3;
    }

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE
    public SerialComm serialComm;

    public float thumbFlexScaled;
    public float thumbAngle;

    public GameObject thumb1;
    public GameObject thumb2;
    public GameObject thumb3;
}