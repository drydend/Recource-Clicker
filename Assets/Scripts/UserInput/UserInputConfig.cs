using UnityEngine;

namespace UserInput
{
    [CreateAssetMenu(menuName = "User Input Config")]
    public class UserInputConfig : ScriptableObject
    {
        [SerializeField]
        private float _cameraOneTouchMoveSensitivity = 1f;
        [SerializeField]
        private float _cameraTwoTouchMoveSensitivity = 1f;
        [SerializeField]
        private float _cameraScaleSensitivity = 1f;

        public float CameraOneTouchMoveSensitivity => _cameraOneTouchMoveSensitivity;
        public float CameraTwoTouchMoveSensitivity =>  _cameraTwoTouchMoveSensitivity;
        public float CameraScaleSensitivity => _cameraScaleSensitivity;
    }
}