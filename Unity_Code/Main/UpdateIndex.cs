using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateIndex : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // PERMANENT CODE
        indexFlexScaled = 0;
        indexAngle = 0;

        index1 = gameObject;
        index2 = gameObject.transform.GetChild(0).gameObject;
        index3 = index2.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        // DEMO PURPOSES ONLY
        /*if (Input.GetKey(KeyCode.R) && indexAngle < 0.0f)
        {
            indexFlexScaled += 0.002f;
        }
        else if (Input.GetKey(KeyCode.F) && indexAngle > -89.0f)
        {
            indexFlexScaled -= 0.002f;
        }*/

        //string[] dataList = dummyData.data.Split('#');
        //string[] dataList = flexTest.data.Split('#');
        //string[] dataList = imuTest.data.Split('#');

        // PERMANENT CODE

        string[] dataList = serialComm.data.Split('#');
        string[] flexData = dataList[0].Split(',');

        indexFlexScaled = int.Parse(flexData[1]) / 1000.0f;

        indexAngle = indexFlexScaled * -90.0f;

        Quaternion rotation1 = index1.transform.localRotation;
        Quaternion rotation2 = index2.transform.localRotation;
        Quaternion rotation3 = index3.transform.localRotation;
        rotation1.eulerAngles = new Vector3(indexAngle, rotation1.eulerAngles.y, rotation1.eulerAngles.z);
        rotation2.eulerAngles = new Vector3(indexAngle, rotation2.eulerAngles.y, rotation2.eulerAngles.z);
        rotation3.eulerAngles = new Vector3(indexAngle, rotation3.eulerAngles.y, rotation3.eulerAngles.z);

        index1.transform.localRotation = rotation1;
        index2.transform.localRotation = rotation2;
        index3.transform.localRotation = rotation3;
    }

    public DummyData dummyData;
    public FlexTest flexTest;
    public IMUTest imuTest;

    // PERMANENT CODE

    public SerialComm serialComm;

    public float indexFlexScaled;
    public float indexAngle;

    public GameObject index1;
    public GameObject index2;
    public GameObject index3;
}
