using UnityEngine;
using Presenter;
using Model;

namespace View
{
    public class PileSpawnerView : MonoBehaviour
    {
        [SerializeField] PileSpawnerModel model;

        PileSpawnerPresenter presenter;
        bool spawning = false;

        void Start()
        {
            presenter = new PileSpawnerPresenter();
            presenter.Model = model;
            Invoke("StartSpawning", 1f);
        }

        void StartSpawning()
        {
            spawning = true;
        }

        void Update()
        {
            if(spawning)
                presenter.Spawning();
        }
    }
}