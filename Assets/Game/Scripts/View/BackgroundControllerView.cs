using UnityEngine;
using Presenter;
using Model;

namespace View
{
    public class BackgroundControllerView : MonoBehaviour
    {
        [SerializeField] BackgroundControllerModel model;

        BackgroundControllerPresenter presenter;

        void Start()
        {
            presenter = new BackgroundControllerPresenter();    
            presenter.Model = model;
        }

        void Update()
        {
            transform.localPosition = presenter.UpdateHorizontalPosition(transform.localPosition, Time.deltaTime, -1);
        }
    }
}