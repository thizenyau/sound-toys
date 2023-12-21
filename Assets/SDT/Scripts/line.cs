using UnityEngine;

public class DrawSineLine : MonoBehaviour
{
    public Theremin.Theremin theremin;
    public Transform transform1;
    public Transform transform2;

    public int points;
    public float amplitude = 1;
    public Vector2 xLimits = Vector2.zero;
    public float movementSpeed = 1;

    private LineRenderer myLineRenderer;

    void Start()
    {
        myLineRenderer = GetComponent<LineRenderer>();
    }

    private void Draw()
    {
        float _freq = theremin._pitch1;
        float _ampl = theremin._volume1 - 0.5f;
        float xStart = 0;
        float Tau = 2 * Mathf.PI;
        float xFinish = Vector3.Distance(transform1.position, transform2.position);

        myLineRenderer.positionCount = points;

        for (int currentPoint = 0; currentPoint < points; currentPoint++)
        {
            float progress = (float)currentPoint / (points - 1);
            float x = Mathf.Lerp(xStart, xFinish, progress);
            float y = _ampl * Mathf.Sin((Tau * _freq * 5 * x) + (Time.timeSinceLevelLoad * movementSpeed));
            Vector3 _vector = Cross();
            Vector3 y_vector = _vector * y;
            Vector3 newPosition = transform1.position + (transform2.position - transform1.position).normalized * x + y_vector;
            myLineRenderer.SetPosition(currentPoint, newPosition);
        }
    }

    void Update()
    {
        Draw();
    }

    public Vector3 Cross()
    {
        Vector3 x = transform2.position - transform1.position;
        Vector3 xProjection = new Vector3(x.x, 0, x.z);
        Vector3 y = Vector3.Cross(x, xProjection);
        Vector3 z = Vector3.Cross(x, y);
        Vector3 z_n = z.normalized;
        return z_n;
    }
}
