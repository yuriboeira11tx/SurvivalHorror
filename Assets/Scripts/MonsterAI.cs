using StarterAssets;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MonsterIA : MonoBehaviour {
    public GameObject playerObj;
    public GameObject gameOverObj;
    public GameObject gameOverUIObj;

    [Header("Sons de passos")]
    public AudioSource audioSource;
    public AudioClip[] sonsDePassos;
    public float intervaloPassos = 2.9f;
    public float velocidadeMinimaParaPasso = 0.9f;

    private float tempoProximoPasso;
    private Vector3 ultimaPosicao;
    private NavMeshAgent agent;

    void Start() {
        ultimaPosicao = transform.position;

        agent = GetComponent<NavMeshAgent>();

        if (audioSource == null) {
            audioSource = GetComponent<AudioSource>();
        }

        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    void Update() {
        if (playerObj != null && agent != null) {
            agent.destination = playerObj.transform.position;
        }

        TocarPassos();
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

    void TocarPassos() {
        float velocidadeAtual = Vector3.Distance(transform.position, ultimaPosicao) / Time.deltaTime;

        if (velocidadeAtual > velocidadeMinimaParaPasso) {
            if (Time.time >= tempoProximoPasso) {
                if (audioSource != null && sonsDePassos != null && sonsDePassos.Length > 0) {
                    AudioClip somEscolhido = sonsDePassos[Random.Range(0, sonsDePassos.Length)];
                    Debug.Log("som");
                    audioSource.PlayOneShot(somEscolhido);

                    tempoProximoPasso = Time.time + intervaloPassos;
                }
            }
        }

        ultimaPosicao = transform.position;
    }
}
