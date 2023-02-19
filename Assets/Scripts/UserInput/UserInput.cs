using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UserInput
{
    public class UserInput : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField]
        private UserInputConfig _config;

        [SerializeField]
        private Camera _camera;
        [SerializeField]
        private CameraMover _cameraMover;

        private int _touchCount;
        private bool _isPressed = false;
        private Vector2? _lastTouchPosition = null;
        private List<Vector2?> _lastTouchesPosition = new List<Vector2?>(2);

        public void OnPointerDown(PointerEventData eventData)
        {
            _touchCount++;
            _isPressed = true;
            ResetTouchesPosition();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _touchCount--;

            if(_touchCount == 0)
            {
                _isPressed = false;
            }

            ResetTouchesPosition();
        }

        private void ResetTouchesPosition()
        {
            _lastTouchPosition = null;
            _lastTouchesPosition[0] = null;
            _lastTouchesPosition[1] = null;
        }

        private void Awake()
        {
            _lastTouchesPosition.Add(null);
            _lastTouchesPosition.Add(null);
        }

        private void Update()
        {
            if (!_isPressed)
            {
                return;
            }

            if (_touchCount == 1)
            {
                UpdateCameraPosition();
            }

            if (_touchCount == 2)
            {
                UpdateCameraScaleAndPosition();
            }
        }

        private void UpdateCameraPosition()
        {
            var touchPosition = _camera.ScreenToWorldPoint(Input.GetTouch(0).position);
            var touchLocalPos = (Vector2)_camera.transform.InverseTransformPoint(touchPosition);

            if (_lastTouchPosition == null)
            {
                _lastTouchPosition = touchLocalPos;
            }

            var displacement = _lastTouchPosition.Value - touchLocalPos;
            _cameraMover.MoveCamera(displacement * _config.CameraOneTouchMoveSensitivity);

            _lastTouchPosition = touchLocalPos;
        }

        private void UpdateCameraScaleAndPosition()
        {
            var firstTouchScrenePosition = Input.GetTouch(0).position;
            var secondTouchScrenePosition = Input.GetTouch(1).position;

            if (_lastTouchesPosition[0] == null || _lastTouchesPosition[1] == null)
            {
                _lastTouchesPosition[0] = firstTouchScrenePosition;
                _lastTouchesPosition[1] = secondTouchScrenePosition;
            }

            UpdatePositionFromTwoTouches(firstTouchScrenePosition, secondTouchScrenePosition, 
                _lastTouchesPosition[0].Value, _lastTouchesPosition[1].Value);

            UpdateScale(firstTouchScrenePosition, secondTouchScrenePosition,
                _lastTouchesPosition[0].Value, _lastTouchesPosition[1].Value);

            _lastTouchesPosition[0] = firstTouchScrenePosition;
            _lastTouchesPosition[1] = secondTouchScrenePosition;
        }

        private void UpdatePositionFromTwoTouches(Vector2 firstTouchScreenPos, Vector2 secondtouchScreenPos,
            Vector2 lastFirstTouchScreenPos, Vector2 lastSecondTouchScreenPos)
        {   
            var firstTouchLocalPos = (Vector2)_camera.transform.InverseTransformPoint(
                _camera.ScreenToWorldPoint(firstTouchScreenPos));
            var secondtouchLocalPos = (Vector2)_camera.transform.InverseTransformPoint(
                _camera.ScreenToWorldPoint(secondtouchScreenPos));

            var lastFirstTouchLocalPos = (Vector2)_camera.transform.InverseTransformPoint(
                _camera.ScreenToWorldPoint(lastFirstTouchScreenPos));
            var lastSecondTouchLocalPos = (Vector2)_camera.transform.InverseTransformPoint(
                _camera.ScreenToWorldPoint(lastSecondTouchScreenPos));

            var displacement = (lastFirstTouchLocalPos - firstTouchLocalPos) + 
                (lastSecondTouchLocalPos - secondtouchLocalPos);

            _cameraMover.MoveCamera(displacement * _config.CameraTwoTouchMoveSensitivity);
        }

        private void UpdateScale(Vector2 firstTouchScreenPos, Vector2 secondtouchScreenPos,
            Vector2 lastFirstTouchScreenPos, Vector2 lastSecondTouchScreenPos)
        {
            var offset = new Vector2(Screen.width / 2, Screen.height / 2);

            firstTouchScreenPos -= offset;
            secondtouchScreenPos -= offset;

            lastFirstTouchScreenPos -= offset;
            lastSecondTouchScreenPos -= offset;

            var previousTouchesDistance = Vector2.Distance(lastFirstTouchScreenPos, lastSecondTouchScreenPos);
            var currentTouchesDistance = Vector2.Distance(firstTouchScreenPos, secondtouchScreenPos);

            var scaleChange = previousTouchesDistance - currentTouchesDistance;

            _cameraMover.ScaleCamera(scaleChange * _config.CameraScaleSensitivity);
        }
    }
}
