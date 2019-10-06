using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSensor : MonoBehaviour
{
    public Transform m_directionVector;
    public LED m_indicator;
    public float m_maxDistance;
    public AudioClip m_sound;

    private bool m_isOn;
    private AudioSource m_source;

    private void Start()
    {
        m_source = gameObject.AddComponent<AudioSource>();
        m_source.clip = m_sound;
        m_source.loop = true;
        m_source.volume = 0;
        m_source.Play();
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(m_directionVector.position, m_directionVector.forward, out RaycastHit hit, m_maxDistance))
        {
            float dis = hit.distance;
            float prop = dis / m_maxDistance; //0 is collision

            if (prop < 0.2f)
            {
                m_indicator.SetColor(Color.red);
                m_source.volume = 1;
            }
            else if (prop >= .3f && prop < .5f)
            {
                m_indicator.SetColor(Color.yellow);
                m_source.volume = .1f;
            }
            else if (prop >=  .6f)
            {
                m_indicator.SetColor(Color.green);
                m_source.volume = 0;
            }
        }
        if (!m_isOn)
        {
            m_indicator.SetColor(Color.black);
            m_source.volume = 0;
        }
    }

    public void SetActive(bool val)
    {
        m_isOn = val;
    }
}
