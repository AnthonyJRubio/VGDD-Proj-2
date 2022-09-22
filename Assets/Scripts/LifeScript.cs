using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Amount of health the heart is at")]
    private int m_Life;
    public int Life
    {
        get
        {
            return m_Life;
        }
    }
    #endregion
}
