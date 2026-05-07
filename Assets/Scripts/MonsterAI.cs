using UnityEngine;
using UnityEngine.AI;

public class MonsterIA : MonoBehaviour {
    GameObject playerObj;
    public GameObject gameOverObj;
    public GameObject gameOverUIObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update() {
        GetComponent<NavMeshAgent>().destination = playerObj.transform.position;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            gameOverObj.SetActive(true);
            gameOverUIObj.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            playerObj.GetComponent<CharacterController>().enabled = false;

            Destroy(this.gameObject);
        }
    }
}
