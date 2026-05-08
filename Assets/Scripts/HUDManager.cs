using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public static HUDManager Instance {get; private set;}

    public Slider staminaSlider;
    public Image staminaColor;
    public GameObject pressE;
    public GameObject monsterObj;
    public GameObject gameOverObj;
    public Text papperCount;
    private int pappers;

    private void Awake() {
        if (Instance != null && Instance == this) {
            Destroy(this);
        } else {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        UpdatePapperCount();

        if (Mouse.current.leftButton.wasPressedThisFrame && gameOverObj.activeSelf) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Cursor.visible = false;
        }
    }

    private void UpdatePapperCount() {
        papperCount.text = pappers.ToString() + "/" + "5";
    }

    public void AddPapper() {
        pappers++;
        monsterObj.SetActive(true);

        if (pappers == 5) {
            monsterObj.SetActive(false);
        }
    }
}
