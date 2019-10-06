using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthCameraController : MonoBehaviour
{
    public float m_snapFrequency = .5f;
    public CameraSnapshot[] m_cameras;
    public DistanceSensor[] m_sensors;

    private int m_selectedCamera = 0;
    private bool m_isShooting;
    private bool m_isActive;

    void Start()
    {
        StartCoroutine(SurveyCO());
    }

    public void SelectCamera(int cam)
    {
        m_selectedCamera = cam;
    }

    public void SetShooting(bool val)
    {
        m_isShooting = val;
    }

    public void SetActive(bool val)
    {
        m_isActive = val;

        foreach (DistanceSensor sensor in m_sensors)
            sensor.SetActive(val);
    }

    private IEnumerator SurveyCO()
    {
        yield return new WaitForSeconds(m_snapFrequency);

        if (m_isShooting)
            m_cameras[m_selectedCamera].TakePhoto(m_isActive);

        StartCoroutine(SurveyCO());
    }
}
