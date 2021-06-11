using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    InputController _inputController;

    private void Start()
    {
        var player = Object.FindObjectOfType<PlayerMovement>();
        _inputController = new InputController(player.GetComponent<PlayerMovement>().Ship, player.transform, player.GetComponent<Shooting>());  
    }
    private void Update()
    {
        _inputController.Execute();
    }
}
