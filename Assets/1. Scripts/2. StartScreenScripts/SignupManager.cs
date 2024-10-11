using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using LootLocker.Requests;

public class SignupManager : MonoBehaviour
{
    
    [SerializeField] private TMP_InputField EmailInputField;
    [SerializeField] private TMP_InputField PasswordInputField;
    [SerializeField] private TextMeshProUGUI StatusText;
    [SerializeField] private Button SubmitButton;
    [SerializeField] private Button ToLoginButton;
   


    void Start()
    {
        SubmitButton.onClick.AddListener(PerformSignUp);
        ToLoginButton.onClick.AddListener(OnLoginButtonClicked);
    }

    private void OnLoginButtonClicked()
    {
        SceneManager.LoadScene("0.StartScene - Login");
    }

    private void PerformSignUp() {
        string email = EmailInputField.text;
        string password = PasswordInputField.text;

        LootLockerSDKManager.WhiteLabelSignUp(email, password, async (signUpResponse) =>
        {
            if (signUpResponse.success) {
                Debug.Log("Sign-Up Successful!");
                StatusText.text = "Sign-Up Successful! Please Log In.";
                SceneManager.LoadScene("0.StartScene - Login");
            } else {
                Debug.Log("Sign-Up Failed.");
                StatusText.text = "Sign-Up Failed, Please Try Again.";
            }
        });
    }

}
