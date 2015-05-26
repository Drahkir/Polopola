using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyCreator : MonoBehaviour
    {
        public float MinSpawnTime = 0.75f;
        public float MaxSpawnTime = 2f;
        public GameObject EnemyPrefab;

        // Use this for initialization
        void Start()
        {
            Invoke("SpawnEnemy", MinSpawnTime);
        }

        // Update is called once per frame
        void Update()
        {
        }

        void SpawnEnemy()
        {
            var camera = Camera.main;
            var cameraPos = camera.transform.position;
            var xMax = camera.aspect * camera.orthographicSize;
            var yMax = camera.orthographicSize;

            var enemyPosition = new Vector3(Random.Range(-xMax, xMax),
                          cameraPos.y + yMax + 1f,
                          EnemyPrefab.transform.position.z);

            Instantiate(EnemyPrefab, enemyPosition, Quaternion.identity);
            Invoke("SpawnEnemy", Random.Range(MinSpawnTime, MaxSpawnTime));
        }
    }
}
