using UnityEngine;
public class CameraController:ICameraController 
{
    public bool CheckInCamera(Collider2D coll, Plane[] cameraFrustum, Camera mainCamera,bool isCameraIn)
    {
        var bounds = coll.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            isCameraIn = true;
        }
        else
        {
            isCameraIn = false;
        }

        return isCameraIn;
    }
}
