using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RegisterPlayer : MonoBehaviour
{
    public Text displayNameInput;
    public Text userNameInput;
    public Text passwordInput;

    public void RegisterPlayerButton()
    {
        Debug.Log("Register Player...");
        new GameSparks.Api.Requests.RegistrationRequest()
            .SetDisplayName(displayNameInput.text)
            .SetUserName(userNameInput.text)
            .SetPassword(passwordInput.text)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player Registered \n User Name: " + response.DisplayName);
                }
                else
                {
                    Debug.Log("Error Registering Player... \n" + response.Errors.JSON.ToString());
                }
            });
    }

}
