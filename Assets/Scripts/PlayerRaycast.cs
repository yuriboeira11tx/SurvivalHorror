using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour {
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        Vector3 direcao = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, direcao * 8f, Color.red);

        bool isHit = Physics.Raycast(transform.position, direcao, out RaycastHit hitInfo, 8f);
        if (isHit) {
            GameObject papelObj = hitInfo.collider.gameObject;
            if (papelObj.tag == "Papel") {
                HUDManager.Instance.pressE.SetActive(true);

                if (Keyboard.current.eKey.wasPressedThisFrame) {
                    Debug.Log("press: " + HUDManager.Instance.pressE.activeSelf);
                    
                    HUDManager.Instance.AddPapper();
                    Destroy(papelObj);
                }
            } else {
                HUDManager.Instance.pressE.SetActive(false);
            }
        }
    }
}
