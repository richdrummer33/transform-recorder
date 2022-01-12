using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PositionRecorder : MonoBehaviour
{
    [SerializeField]
    List<PositionTime> recordedPosnPoints = new List<PositionTime>();
    List<PositionTime> recordedRotPoints = new List<PositionTime>();

    public CubicInterpolator interpolator;

    [SerializeField]
    int frameStep = 10;

    bool recording;

    int frameCt;
    
    void Update()
    {
        if(recording && frameCt % frameStep == 0)
        {
            recordedPosnPoints.Add(new PositionTime(transform.position, Time.time));

            recordedRotPoints.Add(new PositionTime(transform.rotation.eulerAngles, Time.time));
        }

        frameCt++;

        #region Debug controls

        if (Input.GetKeyDown(KeyCode.R)) // Input.GetButtonDown("Right Menu Button"))
        {
            StopAndSaveRecording();
        }

        if(Input.GetKeyDown(KeyCode.P)) // || Input.GetButtonDown("Left Menu Button"))
        {
            LoadAndPlayRecording();
        }

        #endregion
    }

    public void StartRecording()
    {
        recordedPosnPoints = new List<PositionTime>(); // RESET

        recording = true;
    }

    public void StopAndSaveRecording()
    {
        recording = false;

        SavePositionTimeData._instance.SaveAllPositionTimes(recordedPosnPoints, name + "_pos");

        SavePositionTimeData._instance.SaveAllPositionTimes(recordedRotPoints, name + "_rot");
    }

    public void LoadAndPlayRecording()
    {
        List<PositionTime> lastRecordedPoints = SavePositionTimeData._instance.LoadAllPositionTimes(name + "_pos");

        List<PositionTime> lastRecordedRots = SavePositionTimeData._instance.LoadAllPositionTimes(name + "_rot");

        interpolator.StartPlayback(lastRecordedPoints, lastRecordedRots);
    }
}
