using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("Level is finished")]
    private bool m_Finished;
    public bool Finished
    {
        get
        {
            return m_Finished;
        }
    }
    #endregion

    #region Initalization
    public void Awake()
    {
        m_Finished = false;
    }
    #endregion

    #region Finished Methods
    public void LevelOver()
    {
        m_Finished = true;
        Debug.Log("Level Over");
    }
    #endregion
}
