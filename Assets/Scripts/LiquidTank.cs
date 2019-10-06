using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidTank : MonoBehaviour
{
    [Range(0, 100)]
    public float m_initialValue;

    private SkinnedMeshRenderer m_rend;
    private float m_targetValue = 0;
    private float m_value;

    private void Start()
    {
        m_rend = GetComponentInChildren<SkinnedMeshRenderer>(true);

        m_value = m_initialValue;
        m_targetValue = m_value;
    }

    void Update()
    {
        m_value = Mathf.Lerp(m_value, m_targetValue, .1f);
        m_rend.SetBlendShapeWeight(0, 100 - m_value);
    }

    public void SetValue(float val)
    {
        m_targetValue = val;
    }

    public float GetValue()
    {
        return m_value;
    }
}
