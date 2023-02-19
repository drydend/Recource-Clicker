using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(menuName = "Camera config")]
public class CameraCondig : ScriptableObject
{
    [SerializeField]
    private float _minCameraSize;
    [SerializeField]
    private float _maxCameraSize;

    public float MinCameraSize => _minCameraSize;
    public float MaxCameraSize => _maxCameraSize;
}
