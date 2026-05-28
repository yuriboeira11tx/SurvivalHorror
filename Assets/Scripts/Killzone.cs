using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
             int cenaAtual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(cenaAtual);
        }
    }
}
