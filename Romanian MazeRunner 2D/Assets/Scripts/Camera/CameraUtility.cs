using UnityEngine;

public class CameraUtility
{
    private static CameraUtility instance;
    public void moveCameraSmooth(Transform target, Transform cameraTransform, float yOffset, float FollowSpeed)
    {
        if(target != null)
        {
            Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
            cameraTransform.position = Vector3.Slerp(cameraTransform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }

    public static CameraUtility GetInstance()
    {
        if (instance == null)
        {
            instance = new CameraUtility();
        }

        return instance;
    }
}