using UnityEngine;
using View;
using Model;

namespace Presenter
{
    public class PilePresenter
    {
        public PileModel Model;
        float destroyPosX;

        public PilePresenter()
        {
            destroyPosX = -Camera.main.orthographicSize * 2 * Screen.width / Screen.height;
        }

        public Vector3 UpdateMovement(Vector3 position, float dt)
        {
            return position + Vector3.left * Model.horizontalSpeed * dt;
        }

        public bool IsAvailableToDestroy(Vector3 position)
        {
            return position.x < destroyPosX;
        }
    }
}