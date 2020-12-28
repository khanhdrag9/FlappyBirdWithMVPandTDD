using UnityEngine;
using View;
using Model;

namespace Presenter
{
    public class BirdPresenter
    {
        BirdModel model;

        Vector3 flyup;
        public bool IsFlying {get; private set;}

        public BirdPresenter(BirdModel model)
        {
            this.model = model;
        }

        public bool Flyup(Vector3 position)
        {
            if(IsFlying) return false;

            IsFlying = true;
            flyup = position + Vector3.up * model.flyUp;
            return true;
        }

        public Vector3 Update(Vector3 position, float dt)
        {
            if(IsFlying)
                position = Vector3.MoveTowards(position, flyup, model.speedFlyup * dt);

            if(position == flyup)
                IsFlying = false;

            return position;
        }
    }
}