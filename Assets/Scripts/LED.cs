using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LED : MonoBehaviour
{
    public Material m_lightMaterial;
    private Material m_lightMat;

    void Start()
    {
        m_lightMat = new Material(m_lightMaterial);//light

        Material[] sharedMaterialsCopy = GetComponent<MeshRenderer>().sharedMaterials;
        sharedMaterialsCopy[1] = m_lightMat;
        GetComponent<MeshRenderer>().sharedMaterials = sharedMaterialsCopy;
    }

    public void SetColor(Color col)
    {
        m_lightMat.SetColor("_BaseColor", col);
        print(m_lightMat.GetColor("_BaseColor"));
    }

}
