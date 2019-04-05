using UnityEngine;

[RequireComponent(typeof(VIDE_Assign))]
[RequireComponent(typeof(AudioSource))]
public class SimpleDialogAction : MonoBehaviour	{

    [Header("Single Dialog")]
    [SerializeField] VIDE_Assign singleDialog = null;

    [Header("Success & Fail Dialogs")]
    [SerializeField] VIDE_Assign successDialog = null;
    [SerializeField] VIDE_Assign failDialog = null;

    private AudioSource audioSource;

    private void Awake() {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void StartSingleDialog() {
        if (singleDialog != null)
            DialogManager.instance.StartDialog(singleDialog, audioSource);
    }

    public void StartSuccessDialog() {
        if (successDialog != null)
            DialogManager.instance.StartDialog(successDialog, audioSource);
    }

    public void StartFailDialog() {
        if (failDialog != null)
            DialogManager.instance.StartDialog(failDialog, audioSource);
    }






}
