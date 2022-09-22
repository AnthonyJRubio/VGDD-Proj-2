using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Length the grappling hook can go")]
    private float m_Length;
    public float Length
    {
        get
        {
            return m_Length;
        }
    }
    #endregion
}
