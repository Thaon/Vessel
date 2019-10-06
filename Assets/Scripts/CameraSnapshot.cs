using UnityEngine;
using System.Collections;
using System;

public class CameraSnapshot : MonoBehaviour //original from: http://unity.grogansoft.com/in-game-security-camera-using-render-texture/
{
    [SerializeField]
    RenderTexture securityCameraTexture;  // drag the render texture onto this field in the Inspector
    [SerializeField]
    Camera securityCamera; // drag the security camera onto this field in the inspector

    public void TakePhoto(bool isActive)
    {
        print("Taking pic");
        StartCoroutine(SaveCameraView(isActive));
    }

    public IEnumerator SaveCameraView(bool isActive)
    {
        yield return new WaitForEndOfFrame();

        //securityCamera.enabled = true;
        securityCamera.targetTexture = securityCameraTexture;

        // get the camera's render texture
        RenderTexture rendText = RenderTexture.active;
        RenderTexture.active = securityCamera.targetTexture;

        // render the texture
        if (isActive) securityCamera.Render();

        // create a new Texture2D with the camera's texture, using its height and width
        Texture2D cameraImage = new Texture2D(securityCamera.targetTexture.width, securityCamera.targetTexture.height, TextureFormat.RGB24, false);
        cameraImage.ReadPixels(new Rect(0, 0, securityCamera.targetTexture.width, securityCamera.targetTexture.height), 0, 0);
        cameraImage.Apply();
        RenderTexture.active = rendText;
        //securityCamera.enabled = false;

    }
}