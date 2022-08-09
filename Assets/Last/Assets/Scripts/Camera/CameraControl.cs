using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraControl : MonoBehaviour
{

    public Transform m_Targets;
    private Vector3 offset ;
    
    void Start ()
    {
        offset = transform.position ;
        //- m_Targets.position;
    }

    void Update ()
    {
        if (m_Targets != null)
        {
            transform.position = m_Targets.position + offset;
            transform.rotation = m_Targets.rotation;
        }
            
        
    }

    public void SetStartPositionAndSize ()
    {
      
        transform.position = m_Targets.position;
        
    }
}