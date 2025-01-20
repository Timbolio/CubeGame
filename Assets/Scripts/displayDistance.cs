using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;

public class displayDistance : MonoBehaviour
{
    public TMP_Text m_TextMeshPro;
    GameObject obj;

    public void Start() 
    {
        obj = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        float xPos = obj.transform.position.z;
        float xPosRounded = Mathf.Round(xPos);

        m_TextMeshPro.text = Mathf.Abs(xPosRounded).ToString();
    }
}
