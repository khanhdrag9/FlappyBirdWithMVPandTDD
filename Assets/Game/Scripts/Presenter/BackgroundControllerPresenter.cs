using UnityEngine;
using View;
using Model;

namespace Presenter
{
    public class BackgroundControllerPresenter
    {
        public BackgroundControllerModel Model {get; set;}
        public Vector3 UpdateHorizontalPosition(Vector3 currentPosition, float dt, int direction)
        {
            Vector3 result = currentPosition;
            result += Vector3.right * Model.horizontalSpeed * dt * direction;
            if(result.x < Model.minX || result.x > Model.maxX)
                result.x = 0;
            return result;
        }
    }
}