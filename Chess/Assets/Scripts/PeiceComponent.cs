using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeiceComponent : MonoBehaviour
{
    public Vector2 boardPosition;

    private Vector3 lerpFrom = Vector3.zero;
    private Vector3 lerpTo = Vector3.zero;
    private float lerpTime = 0;
    private bool shouldLerp = false;
    private float timeStarted;

    public void startLerp(Vector3 from, Vector3 to, float time = 1)
    {
        shouldLerp = true;
        lerpFrom = from;
        lerpTo = to;
        lerpTime = time;
        timeStarted = Time.time;
    }

    public void Update()
    {
        if (shouldLerp)
        {
            float timeSinceStarted = Time.time - timeStarted;
            float percent = timeSinceStarted / lerpTime;

            gameObject.transform.position = Vector3.Lerp(lerpFrom, lerpTo, percent);

            if (percent >= 1)
            {
                shouldLerp = false;
                gameObject.transform.position = lerpTo;
            }
        }
    }
}
