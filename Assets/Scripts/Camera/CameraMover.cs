using UnityEditor;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private Camera _handledCamera;
    [SerializeField]
    private CameraCondig _cameraConfig;

    public void MoveCamera(Vector2 displacement)
    {
        _handledCamera.transform.position += (Vector3)displacement;
    }

    public void ScaleCamera(float scale)
    {   
        _handledCamera.orthographicSize = Mathf.Clamp(_handledCamera.orthographicSize + scale,
            _cameraConfig.MinCameraSize, _cameraConfig.MaxCameraSize);
    }
}
