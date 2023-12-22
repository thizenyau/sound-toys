using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Theremin;

public class DrawSineLine : MonoBehaviour
{
    public Theremin.Theremin theremin;



    /// <summary>
    /// 渲染多少个点：越多越圆润
    /// </summary>
    public int points;

    /// <summary>
    /// 振幅
    /// </summary>
    [Header("振幅")]
    public float amplitude = 1;

    /// <summary>
    /// 显示多少个周期的图形
    /// </summary>
    [Header("显示多少个周期的图形")]
    public Vector2 xLimits = new Vector2(0,1);

    /// <summary>
    /// 移动速度
    /// </summary>
    [Header("移动速度")]
    public float movementSpeed = 1;

    /// <summary>
    /// 频率
    /// </summary>
    [Header("频率")]
    public float frequency = 1;

    private LineRenderer myLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    /// <summary>
    /// 画sine曲线
    /// </summary>
    private void Draw()
    {
        float _freq = theremin._pitch1;
        float xStart = xLimits.x;
        float Tau = 2 * Mathf.PI;
        float xFinish = xLimits.y;

        myLineRenderer.positionCount = points;

        for(int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = amplitude * Mathf.Sin((Tau * _freq*5*x) + (Time.timeSinceLevelLoad*movementSpeed));
            myLineRenderer.SetPosition(currentPoint,new Vector3(x,y,0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
    }
}

// ————————————————
// 版权声明：本文为CSDN博主「dzj2021」的原创文章，遵循CC 4.0 BY-SA版权协议，转载请附上原文出处链接及本声明。
// 原文链接：https://blog.csdn.net/dzj2021/article/details/124641214