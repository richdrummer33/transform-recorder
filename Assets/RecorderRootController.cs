using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecorderRootController : MonoBehaviour
{
    public List<PositionRecorder> toRecord;

    public void StartRecording()
    {
        foreach(PositionRecorder rec in toRecord)
        {
            rec.StartRecording();
        }
    }

    public void StopRecording()
    {
        foreach (PositionRecorder rec in toRecord)
        {
            rec.StopAndSaveRecording();
        }
    }

    public void LoadAndPlayRecording()
    {
        foreach (PositionRecorder rec in toRecord)
        {
            rec.LoadAndPlayRecording();
        }
    }
}
