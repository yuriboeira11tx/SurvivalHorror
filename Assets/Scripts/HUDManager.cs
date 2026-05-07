using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour {
    public static HUDManager Instance {get; private set;}

    public Slider staminaSlider;
    public Image staminaColor;
    public GameObject pressE;
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
    }

    private void UpdatePapperCount() {
        papperCount.text = pappers.ToString() + "/" + "5";
    }

    public void AddPapper() {
        pappers++;
    }
}
