using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRaycast : MonoBehaviour {
    private bool olhandoParaPapel = false;

    void Update() {
        Vector3 direcao = transform.forward;

        Debug.DrawRay(transform.position, direcao * 8f, Color.red);

        bool achouPapel = false;
        GameObject papelObj = null;

        bool isHit = Physics.Raycast(
            transform.position,
            direcao,
            out RaycastHit hitInfo,
            8f,
            ~0,
            QueryTriggerInteraction.Collide
        );

        if (isHit) {
            GameObject objetoAcertado = hitInfo.collider.gameObject;

            if (objetoAcertado.CompareTag("Papel")) {
                achouPapel = true;
                papelObj = objetoAcertado;
            }
        }

        AtualizarUIInteracao(achouPapel);

        if (achouPapel && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame) {
            HUDManager.Instance.AddPapper();
            Destroy(papelObj);

            AtualizarUIInteracao(false);
        }
    }

    void AtualizarUIInteracao(bool ativo) {
        if (olhandoParaPapel == ativo) {
            return;
        }

        olhandoParaPapel = ativo;

        if (HUDManager.Instance != null && HUDManager.Instance.pressE != null) {
            HUDManager.Instance.pressE.SetActive(ativo);
        }
    }
}