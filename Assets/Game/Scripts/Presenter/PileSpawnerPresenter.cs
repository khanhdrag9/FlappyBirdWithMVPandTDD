using UnityEngine;
using View;
using Model;
using System.Collections.Generic;

namespace Presenter
{
    public class PileSpawnerPresenter
    {
        public class Pair
        {
            public GameObject Top {get; private set;}
            public GameObject Bot {get; private set;}

            public Vector3 Position => Top.transform.position;
            public bool WasDestroyed => Top == null || Bot == null;
            public void Destroy()
            {
                GameObject.Destroy(Top);
                GameObject.Destroy(Bot);
            }

            public Pair(GameObject top, GameObject bot)
            {
                this.Top = top;
                this.Bot = bot;
            }
        }


        public PileSpawnerModel Model {get; set;}
        public Queue<Pair> Piles {get; private set;}
        public float LatestX{get; private set;}


        public PileSpawnerPresenter()
        {
            Piles = new Queue<Pair>();
            LatestX = Camera.main.orthographicSize * Screen.width / Screen.height;
        }

        public void Spawning()
        {
            if(Piles.Count > 0 && Piles.Peek().WasDestroyed)
                Piles.Dequeue();

            if(Piles.Count > Model.maxPileOnScene) return;
            Piles.Enqueue(CreatePile(LatestX));
        }

        public Pair CreatePile(float latestX)
        {
            GameObject prefab = Model.prefab;
            float x = latestX + Model.horizontalDistance;
            float y = Random.Range(-Model.yClamp, Model.yClamp);
            float distance = Random.Range(Model.distanceVerticalMin, Model.distanceVerticalMax) / 2f;

            GameObject top = GameObject.Instantiate(prefab);
            top.transform.localScale = new Vector3(1, -1, 1);
            top.transform.localPosition = new Vector3(x, y + distance, 0);

            GameObject bot = GameObject.Instantiate(prefab);
            bot.transform.localScale = new Vector3(1, 1, 1);
            bot.transform.localPosition = new Vector3(x, y - distance, 0);

            LatestX = x;
            return new Pair(top, bot);
        }

        public void Clear()
        {
            foreach(var e in Piles)
                e.Destroy();
            Piles.Clear();
        }
    }
}