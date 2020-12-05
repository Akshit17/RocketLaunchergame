

using UnityEngine;

public class CameraFollowUp : MonoBehaviour
{
    public Transform target ;
   public float smoothspeed = 10f;
     public Vector3 offset ;
    
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(desiredPosition, target.position, smoothspeed * Time.deltaTime);


        transform.position = smoothedPosition;
    }






























}
