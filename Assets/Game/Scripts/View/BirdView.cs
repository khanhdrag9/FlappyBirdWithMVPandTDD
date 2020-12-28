using UnityEngine;
using Presenter;
using Model;

namespace View
{
    public class BirdView : MonoBehaviour
    {
        [SerializeField] BirdModel model;

        BirdPresenter presenter;
        Rigidbody2D rb;

        void Start()
        {
            presenter = new BirdPresenter(model);    
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            if(IsInput())
            {
                bool isStartFly = presenter.Flyup(transform.localPosition);
                if(isStartFly)
                    rb.velocity = Vector2.zero;
            }

            transform.localPosition = presenter.Update(transform.localPosition, Time.deltaTime);
        }

        bool IsInput()
        {
            return Input.GetMouseButtonDown(0);
        }
    }
}