using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MonsterIA : MonoBehaviour {
    public GameObject playerObj;
    public GameObject gameOverObj;
    public GameObject gameOverUIObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        GetComponent<NavMeshAgent>().destination = playerObj.transform.position;

        if (Mouse.current.leftButton.wasPressedThisFrame && gameOverObj.activeSelf) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
