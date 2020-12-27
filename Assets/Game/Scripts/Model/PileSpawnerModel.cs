using UnityEngine;
using Presenter;

namespace Model
{
    [System.Serializable]
    public class PileSpawnerModel
    {
        public GameObject prefab;

        public int maxPileOnScene;
        public float distanceVerticalMin;
        public float distanceVerticalMax;
        public float horizontalDistance;
        public float yClamp;
    }
}