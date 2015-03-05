using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyCreator : MonoBehaviour
    {
        public float minSpawnTIme = 0.75f;
        public float maxSpawnTime = 2f;
        public GameObject enemyPrefab;

        // Use this for initialization
        void Start()
        {
            Invoke("SpawnEnemy", minSpawnTIme);
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
                          enemyPrefab.transform.position.z);

            Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
            Invoke("SpawnEnemy", Random.Range(minSpawnTIme, maxSpawnTime));
        }
    }
}
