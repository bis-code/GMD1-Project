using UnityEngine;

public class CameraUtility : ICameraUtility
{
    public void moveCameraSmooth(Transform target, Transform cameraTransform, float yOffset, float FollowSpeed)
    {
        if(target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            cameraTransform.position = Vector3.Slerp(cameraTransform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
}