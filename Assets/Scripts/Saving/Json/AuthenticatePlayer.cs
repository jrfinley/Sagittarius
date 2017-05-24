using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;
using System.Text;
using UnityEngine.Experimental.Networking;
using UnityEngine.Networking.Match;
using System.IO;
using GameSparks.Api.Messages;

public class AuthenticatePlayer : MonoBehaviour
{
    public Text userNameInput, passwordInput;
    private string userId;

    public void AuthorizePlayerButton()
    {
        Debug.Log("Authorizing Player...");
        new GameSparks.Api.Requests.AuthenticationRequest()
            .SetUserName(userNameInput.text)
            .SetPassword(passwordInput.text)
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Player Authenticated... \n User Name: " + response.DisplayName);
                }
                else
                {
                    userId = response.UserId;
                    Debug.Log("Error Authenticating Player... \n " + response.Errors.JSON.ToString());
                }
            });
    }
	

    public void AuthenticateDeviceButton()
    {
        Debug.Log("Authenticating Device...");
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .SetDisplayName("Name")
            .Send((response) =>
            {
                if (!response.HasErrors)
                {
                    Debug.Log("Device Authenticated...");
                }
                else
                {
                    Debug.Log("Error Authenticating Device...");
                }
            });
    }
}
