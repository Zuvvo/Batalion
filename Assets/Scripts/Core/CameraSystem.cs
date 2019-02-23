using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    private void Update()
    {
        Vector3 charPos = STF.GameManager.Character.transform.position;
        transform.position = new Vector3(charPos.x, charPos.y, transform.position.z);
    }
}