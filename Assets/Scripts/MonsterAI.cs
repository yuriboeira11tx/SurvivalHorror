using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class MonsterIA : MonoBehaviour {
    public enum MonsterStates { Idle, Patrol, Chase }
    private MonsterStates monsterState = MonsterStates.Patrol;

    public GameObject playerObj;
    public GameObject gameOverObj;
    public GameObject gameOverUIObj;
    public NavMeshAgent agent;
    public Transform centrePoint;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        UpdateState();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            gameOverObj.SetActive(true);
            gameOverUIObj.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            CharacterController controller = playerObj.GetComponent<CharacterController>();
            if (controller != null) {
                controller.enabled = false;
            }

            FirstPersonController firstPersonController = playerObj.GetComponent<FirstPersonController>();
            if (firstPersonController != null) {
                firstPersonController.enabled = false;
            }

            Destroy(gameObject);
        }
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, 15.0f, NavMesh.AllAreas)) {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    private void UpdateState() {
        if (agent.remainingDistance <= agent.stoppingDistance && monsterState == MonsterStates.Patrol) {
            Vector3 point;
            if (RandomPoint(centrePoint.position, 30.0f, out point)) {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
                agent.SetDestination(point);
            }
        }
    }
}
