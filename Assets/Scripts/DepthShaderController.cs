using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthShaderController : MonoBehaviour
{
    public GameObject m_controllerObj;

    private Material m_mat;

    void Start()
    {
        m_mat = GetComponent<MeshRenderer>().sharedMaterial;
    }

    void Update()
    {
        m_mat.SetVector(Shader.PropertyToID("_CamPos"), m_controllerObj.transform.position);
    }
}
