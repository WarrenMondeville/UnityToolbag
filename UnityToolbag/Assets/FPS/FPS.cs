using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS : MonoBehaviour {

    private float m_LastUpdateShowTime = 0f;  //上一次更新帧率的时间;  

    private float m_UpdateShowDeltaTime = 0.01f;//更新帧率的时间间隔;  

    private int m_FrameUpdate = 0;//帧数;  

    private int m_FPS = 0;
    GUIStyle fontStyle;
    void Awake()
    {
       // Application.targetFrameRate = 100;
    }

    // Use this for initialization  
    void Start()
    {
        fontStyle = new GUIStyle();
        fontStyle.normal.background = null;    //设置背景填充  
        fontStyle.normal.textColor = new Color(0, 1, 0);   //设置字体颜色  
        fontStyle.fontSize = 40;       //字体大小  
        m_LastUpdateShowTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame  
    void Update()
    {
        m_FrameUpdate++;
        if (Time.realtimeSinceStartup - m_LastUpdateShowTime >= m_UpdateShowDeltaTime)
        {
            m_FPS =System.Convert.ToInt32( m_FrameUpdate / (Time.realtimeSinceStartup - m_LastUpdateShowTime));
            m_FrameUpdate = 0;
            m_LastUpdateShowTime = Time.realtimeSinceStartup;
        }
    }

    void OnGUI()
    {

        GUI.Label(new Rect(0, 0, 200, 200), m_FPS.ToString(), fontStyle);
        //GUILayout.Label("FPS: " + m_FPS);
        //GUI.Label(new Rect(Screen.width / 10, 10, 100, 100), "FPS: " + m_FPS);
    }
}
