using UnityEngine;

namespace Assets.Scripts
{
    public class FishCreator : MonoBehaviour
    {
        public float minSpawnTIme = 0.75f;
        public float maxSpawnTime = 2f;
        public GameObject fishPrefab;

        // Use this for initialization
        void Start()
        {
            Invoke("SpawnFish", minSpawnTIme);
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

            var enemyPosition = new Vector3(Random.Range(-xMax, xMax),
                          cameraPos.y + yMax + 1f,
                          fishPrefab.transform.position.z);

            Instantiate(fishPrefab, enemyPosition, Quaternion.identity);
            Invoke("SpawnFish", Random.Range(minSpawnTIme, maxSpawnTime));
        }
    }
}
