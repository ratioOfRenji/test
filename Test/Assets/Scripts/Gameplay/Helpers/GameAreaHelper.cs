using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {

        private static Camera _camera;
        

        static GameAreaHelper()
        {
            _camera = Camera.main;

        }

        //public static float camHalfHeight = _camera.orthographicSize;
        //public static float camHalfWidth = camHalfHeight * _camera.aspect;
        //public static Vector3 camPos = _camera.transform.position;
        //public static float leftBound = camPos.x - camHalfWidth;
        //public static float rightBound = camPos.x + camHalfWidth;
        public static bool IsInGameplayArea(Transform objectTransform, Bounds objectBounds)
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = objectTransform.position;

            return (objectPos.x - objectBounds.extents.x < rightBound)
                && (objectPos.x + objectBounds.extents.x > leftBound)
                && (objectPos.y - objectBounds.extents.y < topBound)
                && (objectPos.y + objectBounds.extents.y > bottomBound);

        }

        public static float rightBound(Transform objectTransform, Bounds objectBounds)
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - camHalfWidth;
            var rightBound = camPos.x + (camHalfWidth -3);

            var objectPos = objectTransform.position;
            return rightBound;

           
        }
        public static float leftBound(Transform objectTransform, Bounds objectBounds)
        {
            var camHalfHeight = _camera.orthographicSize;
            var camHalfWidth = camHalfHeight * _camera.aspect;
            var camPos = _camera.transform.position;
            var topBound = camPos.y + camHalfHeight;
            var bottomBound = camPos.y - camHalfHeight;
            var leftBound = camPos.x - (camHalfWidth -3);
            var rightBound = camPos.x + camHalfWidth;

            var objectPos = objectTransform.position;
            return leftBound;


        }

    }
}
