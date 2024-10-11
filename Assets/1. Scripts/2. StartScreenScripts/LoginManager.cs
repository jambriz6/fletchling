using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using LootLocker.Requests;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField EmailInputField;
    [SerializeField] private TMP_InputField PasswordInputField;
    [SerializeField] private Button LoginButton;
    [SerializeField] private Button ToSignupButton;
    [SerializeField] private TextMeshProUGUI StatusText;

    private void Start()
    {
        LoginButton.onClick.AddListener(PerformLogin);
        ToSignupButton.onClick.AddListener(OnSignupButtonClicked);
        LootLockerSDKManager.CheckWhiteLabelSession(response =>
        {
            if (response) {
                Debug.Log("session is valid");
                //StartGameSession();
            } else {
                Debug.Log("session is NOT valid");
            }
        });
    }

    private void OnSignupButtonClicked()
    {
        SceneManager.LoadScene("0.StartScene - Signup");
    }

    private void PerformLogin()
    {
        string email = EmailInputField.text;
        string password = PasswordInputField.text;

        LootLockerSDKManager.WhiteLabelLogin(email, password, true, (loginResponse) =>
        {
            if (loginResponse.success)
            {
                Debug.Log("Login Successful!");
                StatusText.text = "Login Successful!";
                StartGameSession();
            } else {
                Debug.Log("Login Failed");
                StatusText.text = "Login Failed, Check your Credentials.";
            }
        });
    }

    private void StartGameSession()
    {
        LootLockerSDKManager.StartWhiteLabelSession((sessionResponse) =>
        {
            if (sessionResponse.success)
            {
                Debug.Log("Session started successfully");
                StatusText.text = "Session started successfully.";
                UnityEngine.SceneManagement.SceneManager.LoadScene("1.GameHub");
            }
            else
            {
                Debug.Log("Error starting LootLocker session");
                StatusText.text = "Error starting session, please try again.";
            }
        });
    }

    // Toggle visibility of password characters
    public void TogglePasswordVisibility(bool visible)
    {
        PasswordInputField.contentType = visible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        PasswordInputField.ForceLabelUpdate();
    }

    // Call this method from a UI toggle or button to toggle password visibility
    public void OnTogglePasswordVisibility(bool visible)
    {
        TogglePasswordVisibility(visible);
    }
}
