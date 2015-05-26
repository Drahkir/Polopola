using UnityEngine;

namespace Assets.Scripts
{
    public class FishCreator : MonoBehaviour
    {
        public float MinSpawnTime = 0.75f;
        public float MaxSpawnTime = 2f;
        public GameObject FishPrefab;

        // Use this for initialization
        void Start()
        {
            Invoke("SpawnFish", MinSpawnTime);
        }

        // Update is called once per frame
        void Update()
        {
        }

        void SpawnFish()
        {
            var camera = Camera.main;
            var cameraPos = camera.transform.position;
            var xMax = camera.aspect * camera.orthographicSize;
            var yMax = camera.orthographicSize;

            var fishPosition = new Vector3(Random.Range(-xMax, xMax),
                          cameraPos.y + yMax + 1f,
                          FishPrefab.transform.position.z);

            Instantiate(FishPrefab, fishPosition, Quaternion.identity);
            Invoke("SpawnFish", Random.Range(MinSpawnTime, MaxSpawnTime));
        }
    }
}
