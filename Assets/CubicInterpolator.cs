﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubicInterpolator : MonoBehaviour
{
    List<PositionTime> recdPts = new List<PositionTime>();
    List<PositionTime> recdPtsRot = new List<PositionTime>();
    //public List<Transform> pointTransforms = new List<Transform>();

     Transform mover;

    int index = 1;

    Vector3 interpPosn;
    float t;

    bool play;

    private void Start()
    {
        mover = transform;
    }

    public void StartPlayback(List<PositionTime> recordedPoints, List<PositionTime> recordedRots)
    {
        recdPts = recordedPoints;
        recdPtsRot = recordedRots;

        List<Vector3> points = new List<Vector3>();
        List<PositionTime> temp = new List<PositionTime>();

        // SASADADS
        foreach (PositionTime t in recdPts)
        {
            points.Add(t.position);
        }

        PositionTime pt = new PositionTime(recdPts[0].position + (recdPts[0].position - recdPts[1].position), -1f);

        temp.Add(pt);

        temp.AddRange(recdPts);

        pt = new PositionTime(recdPts[recdPts.Count - 1].position + (recdPts[recdPts.Count - 1].position - recdPts[recdPts.Count - 2].position), recdPts[recdPts.Count - 1].time + 1f);

        temp.Add(pt);

        recdPts = temp;
        // SASADADS

        // ZXCZXC
        points = new List<Vector3>();
        temp = new List<PositionTime>();

        foreach (PositionTime t in recdPtsRot)
        {
            points.Add(t.position);
        }

        pt = new PositionTime(recdPtsRot[0].position + (recdPtsRot[0].position - recdPtsRot[1].position), -1f);

        temp.Add(pt);

        temp.AddRange(recdPtsRot);

        pt = new PositionTime(recdPtsRot[recdPtsRot.Count - 1].position + (recdPtsRot[recdPtsRot.Count - 1].position - recdPtsRot[recdPtsRot.Count - 2].position), recdPtsRot[recdPtsRot.Count - 1].time + 1f);

        temp.Add(pt);

        recdPtsRot = temp;
        // ZXCZXC

        index = 1;
        play = true;
    }

    void Update() // Actually cubic
    {
        if (play && index < recdPts.Count - 2)
        {
            UpdatePosition();
        }
    }

    Quaternion startRot;

    void UpdatePosition()
    {
        Vector3 p0 = recdPts[index - 1].position;
        Vector3 p1 = recdPts[index + 0].position;
        Vector3 p2 = recdPts[index + 1].position;
        Vector3 p3 = recdPts[index + 2].position;

        float dt = recdPts[index + 1].time - recdPts[index + 0].time;
        Vector3 absDirNorm = recdPts[index + 1].position - recdPts[index + 0].position;

        float t2 = Mathf.Pow(t / dt, 2f); // (1 - Mathf.Cos(t * Mathf.PI)) / 2f;

        Vector3 a0 = p3 - p2 - p0 + p1;
        Vector3 a1 = p0 - p1 - a0;
        Vector3 a2 = p2 - p0;
        Vector3 a3 = p1;

        interpPosn = a0 * t / dt * t2 + a1 * t2 + a2 * t / dt + a3;// p1 * (1 - mu2) + p2 * mu2;

        //float dAngle = Vector3.Angle(interpPosn - mover.position, absDirNorm);

        //float velMod = Mathf.Sin(dAngle / 360f * 2 * Mathf.PI);

        mover.position = interpPosn;

        t += Time.deltaTime;

        transform.rotation = Quaternion.Lerp(startRot, Quaternion.Euler(recdPtsRot[index + 1].position), t / dt);

        if (t / dt >= 1f)
        {
            index++;
            t = 0f;
            startRot = transform.rotation;
        }
    }
}

[System.Serializable]
public class PositionTime : MonoBehaviour
{
    public Vector3 position;
    public float time;

    public PositionTime(Vector3 position, float time)
    {
        this.position = position;
        this.time = time;
    }
}