using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Valve.VR;

public class PlayerMove : MonoBehaviour
{
    // ���������� ��� ���������� ������������ SteamVR
    private SteamVR_Action_Vector2 touchpad = SteamVR_Actions._default.Touchpad;
    private SteamVR_Action_Boolean m_Boolean = SteamVR_Actions._default.TouchClick;

    private CharacterController controller = null; // ��������� CharacterController ��� ����������� ������

    public float speed = 1f; // �������� ����������� ������
    private bool checkWalk = false; // ���������� ��� ��������, ����� ����� ���������� ������

    private void Awake()
    {
        // �������� ������ �� �������� ����������� SteamVR
        touchpad = SteamVR_Actions._default.Touchpad;    
        m_Boolean = SteamVR_Actions._default.TouchClick;    
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // print("11111111111111111111111111111111111111111111111");
        // ���� ������ �� ������ ����� ������� �����������
        if (m_Boolean.GetStateDown(SteamVR_Input_Sources.RightHand))
        {
     //   print("2222222222222222222222222222222222222222222222222");
            // �������� ����������� ������
            checkWalk = true;
        }

        // ���� ��������� ������ ����� ������� �����������
        if (m_Boolean.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
         //   print("3333333333333333333333333333333333333333333333333");

                m_Boolean = SteamVR_Actions._default.TouchClick;   
            // ��������� ����������� ������
            checkWalk = false;
        }

        // ���� ����������� ������� � ����� ����� �� ������� �����������
        if (checkWalk && touchpad.axis.magnitude > 0.1f)
        {
         //   print("44444444444444444444444444444444444444444444444444444444444444444444444");

            // �������� ����������� �������� ������
            Vector3 direction = Player.instance.hmdTransform.TransformDirection(new Vector3(touchpad.axis.x, 0, touchpad.axis.y));
            // ���������� ������ � ��������� �����������
            controller.Move(speed * Time.deltaTime * Vector3.ProjectOnPlane(direction, Vector3.up) - new Vector3(0, 9.81f, 0) * Time.deltaTime);
        }
    }
}
