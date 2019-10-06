using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    #region member variables

    public GameObject m_ship;
    public Crank m_pitchCrank, m_speedCrank;
    public Valve m_steeringValve;
    public LiquidTank m_fuelTank;
    public float m_speed;
    public float m_steeringAmount;
    public float m_pitchingAmount;
    public float m_fuel;
    public float m_fuelConsumptionRate;

    private bool m_engineOn, m_sensorsOn;
    private Rigidbody m_rb;
    private float m_startingFuel;

    #endregion

    void Start()
    {
        m_rb = m_ship.GetComponent<Rigidbody>();
        m_startingFuel = m_fuel;
    }

    void FixedUpdate()
    {
        if (m_engineOn)
        {
            float speed = m_speedCrank.GetValue();
            float steering = m_steeringValve.GetRotation();
            float pitch = m_pitchCrank.GetValue(); //needs remapped
            pitch = pitch * 2 - 1; // -1 and 1

            //m_ship.transform.Rotate(Vector3.up, steering * m_steeringAmount, Space.Self);//steer
            m_ship.transform.Rotate(Vector3.right, pitch * m_pitchingAmount, Space.Self);//pitch

            m_rb.AddForce(m_ship.transform.forward * m_speed * speed);
            m_rb.AddTorque(m_rb.transform.up * steering * m_steeringAmount, ForceMode.Force);

            m_fuel -= m_fuelConsumptionRate * Time.deltaTime;
            m_fuelTank.SetValue(100 * (m_fuel / m_startingFuel));

            if (m_fuel <= 0)
                FindObjectOfType<EndOfLevelTrigger>().GameOver();
        }
    }

    public void TurnOnEngine()
    {
        m_engineOn = true;
    }

    public void TurnOffEngine()
    {
        m_engineOn = false;
    }

    public void TurnOnSensors()
    {
        m_sensorsOn = true;
    }

    public void TurnOffSensors()
    {
        m_sensorsOn = false;
    }
}
