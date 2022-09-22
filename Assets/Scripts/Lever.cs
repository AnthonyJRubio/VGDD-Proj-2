using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever: MonoBehaviour
{
    #region Editor Variables
    private Renderer rend;
    [SerializeField]
    [Tooltip("Color to change to once flipped")]
    private Color newColor = Color.blue;

    [SerializeField]
    [Tooltip("Wheher gravity has been flipped")]
    private int m_GravMult;
    public int GravMult
    {
        get
        {
            return m_GravMult;
        }
    }
    #endregion

    #region Initialization
    private void Awake()
    {
        //start rendering button
        rend = GetComponent<Renderer>();
    }
    #endregion

    #region Grav Editor
    public void GravChange()
    {
        m_GravMult *= -1;
        rend.material.color = newColor; // this will change the color when activated, confirmed works
    }
    #endregion
}
