using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System;

public class SerialComm : MonoBehaviour
{

    public string data;

    public string commPort = "COM12";
    public int baudRate = 9600;
    private SerialPort stream;

    // Start is called before the first frame update
    void Start()
    {
        stream = new SerialPort(commPort, baudRate);
        stream.ReadTimeout = 50;
        stream.Open();

    }

    // Update is called once per frame
    void Update()
    {/*
        string s = ReadFromArduino(10000);
        data = s + ",0,0,0,0#0,0,0,0;0,0,0#0,0,0,0;0,0,0";
        Debug.Log(data);*/

        StartCoroutine
        (
            AsynchronousReadFromArduino
            ((string s) => data = s,            // Callback
                () => Debug.LogError("Error!"), // Error callback
                10000f                          // Timeout (milliseconds)
            )
        );
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public string ReadFromArduino(int timeout = 0)
    {
        stream.ReadTimeout = timeout;
        try
        {
            return stream.ReadLine();
        }
        catch (TimeoutException)
        {
            return null;
        }
    }

    public IEnumerator AsynchronousReadFromArduino(Action<string> callback, Action fail = null, float timeout = float.PositiveInfinity)
    {
        DateTime initialTime = DateTime.Now;
        DateTime nowTime;
        TimeSpan diff = default(TimeSpan);

        string dataString = null;

        do
        {
            try
            {
                dataString = stream.ReadLine();
                Debug.Log(dataString);
            }
            catch (TimeoutException)
            {
                dataString = null;
            }

            if (dataString != null)
            {
                callback(dataString);
                yield break; // Terminates the Coroutine
            }
            else
                yield return null; // Wait for next frame

            nowTime = DateTime.Now;
            diff = nowTime - initialTime;

        } while (diff.Milliseconds < timeout);

        if (fail != null)
            fail();
        yield return null;
    }

    void OnDestroy()
    {
        // Close the port when the program ends.
        if (stream.IsOpen)
        {
            try
            {
                stream.Close();
            }
            catch (UnityException e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}

