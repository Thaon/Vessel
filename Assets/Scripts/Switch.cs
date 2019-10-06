using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    public AudioClip m_sound;
    public bool m_isTwoStates = true;
    public UnityEvent IsSwitchedOn, IsSwitchedOff;

    private bool m_isOn;
    private Animator m_anim;
    private AudioSource m_audio;
    private bool m_canBeClicked = true;

    void Start()
    {
        m_anim = GetComponent<Animator>();
        m_audio = gameObject.AddComponent<AudioSource>();
    }

    public void Activate()
    {
        if (m_canBeClicked)
        {
            m_canBeClicked = false;
            StartCoroutine(ActivateCO());
        }
    }

    private IEnumerator ActivateCO()
    {
        yield return new WaitForEndOfFrame();

        m_audio.PlayOneShot(m_sound);
        m_isOn = !m_isOn;
        m_anim.SetBool("IsOn", m_isOn);

        if (m_isOn == true) IsSwitchedOn.Invoke(); else IsSwitchedOff.Invoke();

        yield return new WaitForSeconds(.5f);

        m_canBeClicked = true;

        if (!m_isTwoStates && m_isOn)
            Activate();
    }

    public bool GetState()
    {
        return m_isOn;
    }
}
