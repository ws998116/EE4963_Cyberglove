using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateRing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PERMANENT CODE
        ringFlexScaled = 0;
        ringAngle = 0;

        ring1 = gameObject;
        ring2 = gameObject.transform.GetChild(0).gameObject;
        ring3 = ring2.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*if (Input.GetKey(KeyCode.R) && ringAngle < 0.0f)
        {
            ringFlexScaled += 0.002f;
        }
        else if (Input.GetKey(KeyCode.F) && ringAngle > -89.0f)
        {
            ringFlexScaled -= 0.002f;
        }*/

        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] flexData = dataList[0].Split(',');

        ringFlexScaled = int.Parse(flexData[3]) / 1000.0f;
        ringAngle = ringFlexScaled * -90.0f;

        Quaternion rotation1 = ring1.transform.localRotation;
        Quaternion rotation2 = ring2.transform.localRotation;
        Quaternion rotation3 = ring3.transform.localRotation;
        rotation1.eulerAngles = new Vector3(ringAngle, rotation1.eulerAngles.y, rotation1.eulerAngles.z);
        rotation2.eulerAngles = new Vector3(ringAngle, rotation2.eulerAngles.y, rotation2.eulerAngles.z);
        rotation3.eulerAngles = new Vector3(ringAngle, rotation3.eulerAngles.y, rotation3.eulerAngles.z);

        ring1.transform.localRotation = rotation1;
        ring2.transform.localRotation = rotation2;
        ring3.transform.localRotation = rotation3;
    }

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE

    public SerialComm serialComm;

    public float ringFlexScaled;
    public float ringAngle;

    public GameObject ring1;
    public GameObject ring2;
    public GameObject ring3;
}
