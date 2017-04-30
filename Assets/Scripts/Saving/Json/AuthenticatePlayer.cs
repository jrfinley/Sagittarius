﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AuthenticatePlayer : MonoBehaviour
{
    public Text userNameInput, passwordInput;

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
                    Debug.Log("Error Authenticating Player... \n " + response.Errors.JSON.ToString());
                }
            });
    }
	

    public void AuthenticateDeviceButton()
    {
        Debug.Log("Authenticating Device...");
        new GameSparks.Api.Requests.DeviceAuthenticationRequest()
            .SetDisplayName("Phil")
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
