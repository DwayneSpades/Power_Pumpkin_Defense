// GENERATED AUTOMATICALLY FROM 'Assets/demo_scripts/input/playerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""playerInput"",
    ""maps"": [
        {
            ""name"": ""playerController"",
            ""id"": ""33399018-a043-4608-9be0-1644390cf753"",
            ""actions"": [
                {
                    ""name"": ""left_stick"",
                    ""type"": ""Value"",
                    ""id"": ""05304ded-b6ac-444c-bc52-796dc57c6655"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""right_stick"",
                    ""type"": ""Value"",
                    ""id"": ""1f0142d9-0811-4f0e-9ca8-55bc92a69b1f"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""snapCamFWD"",
                    ""type"": ""Button"",
                    ""id"": ""47d50777-a96e-4a2b-bec6-9241039ef7e8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""jump"",
                    ""type"": ""Button"",
                    ""id"": ""db27088a-39b5-4442-b5c8-9defeda0a3a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""sprint"",
                    ""type"": ""Button"",
                    ""id"": ""76cad58e-e763-45eb-b4b6-aa20ce1e14f7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""26a064c1-9e4f-4d07-8b18-a84fe3542f46"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5e41bb1e-6480-4291-8742-c8fffc248bb0"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_stick"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bd9d6825-1a93-4263-a7a1-c6abe553d4be"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8c27a12a-26ea-4fad-9167-1fdc095d8d50"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""90004997-5cee-489f-bbc6-a268b3928f98"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6c1456cc-782b-431b-946b-73d4a56b0ccd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""left_stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e9c6cc30-202c-483d-9e3a-faac7bd15249"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""right_stick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c92e4059-680d-4b92-b02e-2c9bbe10b85d"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""snapCamFWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""807cb727-f28d-44f3-99a7-c41801e8b85b"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""snapCamFWD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3549a1a5-ff25-451d-8eef-9871a25ab001"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7f65d324-8469-4673-8a51-069bad4b2fc2"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0973b86-d6a3-4c69-b2e0-3173ed252f27"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""df0de0cb-778d-4498-841e-b90445691e79"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // playerController
        m_playerController = asset.FindActionMap("playerController", throwIfNotFound: true);
        m_playerController_left_stick = m_playerController.FindAction("left_stick", throwIfNotFound: true);
        m_playerController_right_stick = m_playerController.FindAction("right_stick", throwIfNotFound: true);
        m_playerController_snapCamFWD = m_playerController.FindAction("snapCamFWD", throwIfNotFound: true);
        m_playerController_jump = m_playerController.FindAction("jump", throwIfNotFound: true);
        m_playerController_sprint = m_playerController.FindAction("sprint", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // playerController
    private readonly InputActionMap m_playerController;
    private IPlayerControllerActions m_PlayerControllerActionsCallbackInterface;
    private readonly InputAction m_playerController_left_stick;
    private readonly InputAction m_playerController_right_stick;
    private readonly InputAction m_playerController_snapCamFWD;
    private readonly InputAction m_playerController_jump;
    private readonly InputAction m_playerController_sprint;
    public struct PlayerControllerActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @left_stick => m_Wrapper.m_playerController_left_stick;
        public InputAction @right_stick => m_Wrapper.m_playerController_right_stick;
        public InputAction @snapCamFWD => m_Wrapper.m_playerController_snapCamFWD;
        public InputAction @jump => m_Wrapper.m_playerController_jump;
        public InputAction @sprint => m_Wrapper.m_playerController_sprint;
        public InputActionMap Get() { return m_Wrapper.m_playerController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerControllerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerControllerActions instance)
        {
            if (m_Wrapper.m_PlayerControllerActionsCallbackInterface != null)
            {
                @left_stick.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnLeft_stick;
                @left_stick.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnLeft_stick;
                @left_stick.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnLeft_stick;
                @right_stick.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnRight_stick;
                @right_stick.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnRight_stick;
                @right_stick.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnRight_stick;
                @snapCamFWD.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSnapCamFWD;
                @snapCamFWD.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSnapCamFWD;
                @snapCamFWD.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSnapCamFWD;
                @jump.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJump;
                @jump.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJump;
                @jump.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnJump;
                @sprint.started -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSprint;
                @sprint.performed -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSprint;
                @sprint.canceled -= m_Wrapper.m_PlayerControllerActionsCallbackInterface.OnSprint;
            }
            m_Wrapper.m_PlayerControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @left_stick.started += instance.OnLeft_stick;
                @left_stick.performed += instance.OnLeft_stick;
                @left_stick.canceled += instance.OnLeft_stick;
                @right_stick.started += instance.OnRight_stick;
                @right_stick.performed += instance.OnRight_stick;
                @right_stick.canceled += instance.OnRight_stick;
                @snapCamFWD.started += instance.OnSnapCamFWD;
                @snapCamFWD.performed += instance.OnSnapCamFWD;
                @snapCamFWD.canceled += instance.OnSnapCamFWD;
                @jump.started += instance.OnJump;
                @jump.performed += instance.OnJump;
                @jump.canceled += instance.OnJump;
                @sprint.started += instance.OnSprint;
                @sprint.performed += instance.OnSprint;
                @sprint.canceled += instance.OnSprint;
            }
        }
    }
    public PlayerControllerActions @playerController => new PlayerControllerActions(this);
    public interface IPlayerControllerActions
    {
        void OnLeft_stick(InputAction.CallbackContext context);
        void OnRight_stick(InputAction.CallbackContext context);
        void OnSnapCamFWD(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
    }
}
