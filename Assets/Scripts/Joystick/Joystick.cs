using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private PlayerMoveJoystick m_PlayerMoveJoystick;

    void Start() {
        m_PlayerMoveJoystick = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoveJoystick>();
    }

    public void OnPointerDown(PointerEventData data) {
        if(gameObject.name == "Left") {
            m_PlayerMoveJoystick.SetMoveLeft(true);
        } else {
            m_PlayerMoveJoystick.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data) {
        m_PlayerMoveJoystick.StopMoving();
    }

}
