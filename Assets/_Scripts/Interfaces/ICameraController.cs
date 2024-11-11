using UnityEngine;
public interface ICameraController
{
    public bool CheckInCamera(Collider2D coll, Plane[] cameraFrustum, Camera mainCamera,bool isCameraIn);
}
