using UnityEngine;
using Presenter;
using Model;

namespace View
{
    public class PileView : MonoBehaviour
    {
        [SerializeField] PileModel model;
        PilePresenter presenter;
        void Start()
        {
            presenter = new PilePresenter();
            presenter.Model = model;
        }

        void Update()
        {
            if(presenter.IsAvailableToDestroy(transform.localPosition))
            {
                Destroy(gameObject);
                return;
            }

            transform.localPosition = presenter.UpdateMovement(transform.localPosition, Time.deltaTime);
        }
    }
}