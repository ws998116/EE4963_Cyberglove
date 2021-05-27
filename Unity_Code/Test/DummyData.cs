using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        data = "0,0,0,0,0#0,0,0,0;0,0,0#0,0,0,0;0,0,0";
    }

    // Update is called once per frame
    void Update()
    {

        frames++;
        if (frames % rand1 == 0)
        {
            otherWay1 *= -1;
            rand1 = Random.Range(300, 1000);
        }
        if (frames % rand2 == 0)
        {
            otherWay2 *= -1;
            rand2 = Random.Range(300, 1000);
        }
        if (frames % rand3 == 0)
        {
            otherWay3 *= -1;
            rand3 = Random.Range(300, 1000);
        }
        if (frames % rand4 == 0)
        {
            otherWay4 *= -1;
            rand4 = Random.Range(300, 1000);
        }
        if (frames % rand5 == 0)
        {
            otherWay5 *= -1;
            rand5 = Random.Range(300, 1000);
        }

        int add = Random.Range(0, 5);
        lastUpdateThumb += add * otherWay1;
        if (lastUpdateThumb > 1000) { lastUpdateThumb = 1000; }
        if (lastUpdateThumb < 0) { lastUpdateThumb = 0; }

        add = Random.Range(0, 5);
        lastUpdateIndex += add * otherWay2;
        if (lastUpdateIndex > 1000) { lastUpdateIndex = 1000; }
        if (lastUpdateIndex < 0) { lastUpdateIndex = 0; }

        add = Random.Range(0, 5);
        lastUpdateMiddle += add * otherWay3;
        if (lastUpdateMiddle > 1000) { lastUpdateMiddle = 1000; }
        if (lastUpdateMiddle < 0) { lastUpdateMiddle = 0; }

        add = Random.Range(0, 5);
        lastUpdateRing += add * otherWay4;
        if (lastUpdateRing > 1000) { lastUpdateRing = 1000; }
        if (lastUpdateRing < 0) { lastUpdateRing = 0; }

        add = Random.Range(0, 5);
        lastUpdatePinky += add * otherWay5;
        if (lastUpdatePinky > 1000) { lastUpdatePinky = 1000; }
        if (lastUpdatePinky < 0) { lastUpdatePinky = 0; }

        //

        add = Random.Range(0, 2);
        lastWristRotI += add * otherWay2;
        if (lastWristRotI > 1000) { lastWristRotI = 1000; }
        if (lastWristRotI < 0) { lastWristRotI = 0; }

        add = Random.Range(0, 3);
        lastWristRotJ += add * otherWay3;
        if (lastWristRotJ > 1000) { lastWristRotJ = 1000; }
        if (lastWristRotJ < -1000) { lastWristRotJ = -1000; }

        add = Random.Range(0, 3);
        lastWristRotK += add * otherWay4;
        if (lastWristRotK > 1000) { lastWristRotK = 1000; }
        if (lastWristRotK < -1000) { lastWristRotK = -1000; }

        add = Random.Range(0, 2);
        lastWristRotL += add * otherWay5;
        if (lastWristRotL > 1000) { lastWristRotL = 1000; }
        if (lastWristRotL < -1000) { lastWristRotL = -1000; }

        //

        add = Random.Range(0, 5);
        lastWristPosX += add * otherWay4;
        if (lastWristPosX > 1000) { lastWristPosX = 1000; }
        if (lastWristPosX < -1000) { lastWristPosX = -1000; }

        add = Random.Range(0, 5);
        lastWristPosY += add * otherWay2;
        if (lastWristPosY > 1000) { lastWristPosY = 1000; }
        if (lastWristPosY < -1000) { lastWristPosY = -1000; }

        add = Random.Range(0, 5);
        lastWristPosZ += add * otherWay5;
        if (lastWristPosZ > 1000) { lastWristPosZ = 1000; }
        if (lastWristPosZ < -1000) { lastWristPosZ = -1000; }

        //
        /*
        add = Random.Range(0, 2);
        lastForearmRotI += add * otherWay2;
        if (lastForearmRotI > 1000) { lastForearmRotI = 1000; }
        if (lastForearmRotI < 0) { lastForearmRotI = 0; }

        add = Random.Range(0, 2);
        lastForearmRotL += add * otherWay5;
        if (lastForearmRotL > 1000) { lastForearmRotL = 1000; }
        if (lastForearmRotL < -1000) { lastForearmRotL = -1000; }

        add = Random.Range(0, 3);
        lastForearmRotJ += add * otherWay3;
        if (lastForearmRotJ > 1000) { lastForearmRotJ = 1000; }
        if (lastForearmRotJ < -1000) { lastForearmRotJ = -1000; }

        add = Random.Range(0, 3);
        lastForearmRotK += add * otherWay4;
        if (lastForearmRotK > 1000) { lastForearmRotK = 1000; }
        if (lastForearmRotK < -1000) { lastForearmRotK = -1000; }
        */
        //

        add = Random.Range(0, 2);
        lastForearmPosX += add * otherWay1;
        if (lastForearmPosX > 1000) { lastForearmPosX = 1000; }
        if (lastForearmPosX < -1000) { lastForearmPosX = -1000; }

        add = Random.Range(0, 2);
        lastForearmPosY += add * otherWay2;
        if (lastForearmPosY > 1000) { lastForearmPosY = 1000; }
        if (lastForearmPosY < -1000) { lastForearmPosY = -1000; }

        add = Random.Range(0, 2);
        lastForearmPosZ += add * otherWay3;
        if (lastForearmPosZ > 1000) { lastForearmPosZ = 1000; }
        if (lastForearmPosZ < -1000) { lastForearmPosZ = -1000; }

        data = lastUpdateThumb + "," + lastUpdateIndex + "," + lastUpdateMiddle + "," + lastUpdateRing + "," + lastUpdatePinky +
            "#" + lastWristRotI + "," + lastWristRotJ + "," + lastWristRotK + "," + lastWristRotL +
            ";" + lastWristPosX + "," + lastWristPosY + "," + lastWristPosZ +
            "#" + lastForearmRotI + "," + lastForearmRotJ + "," + lastForearmRotK + "," + lastForearmRotL +
            ";" + lastForearmPosX + "," + lastForearmPosY + "," + lastForearmPosZ ;

        Debug.Log(data);
    }

    public string data;

    private int frames = 0;
    private int rand1 = 300;
    private int rand2 = 800;
    private int rand3 = 500;
    private int rand4 = 700;
    private int rand5 = 200;
    int otherWay1 = 1;
    int otherWay2 = 1;
    int otherWay3 = 1;
    int otherWay4 = 1;
    int otherWay5 = 1;

    int lastUpdateIndex = 0;
    int lastUpdateMiddle = 0;
    int lastUpdateRing = 0;
    int lastUpdatePinky = 0;
    int lastUpdateThumb = 0;

    public int lastWristRotI = 0;
    public int lastWristRotJ = 0;
    public int lastWristRotK = 0;
    public int lastWristRotL = 1;

    public int lastWristPosX = 0;
    public int lastWristPosY = 0;
    public int lastWristPosZ = 0;

    public int lastForearmRotI = 0;
    public int lastForearmRotJ = 0;
    public int lastForearmRotK = 0;
    public int lastForearmRotL = 1;

    public int lastForearmPosX = 0;
    public int lastForearmPosY = 0;
    public int lastForearmPosZ = 0;
}
