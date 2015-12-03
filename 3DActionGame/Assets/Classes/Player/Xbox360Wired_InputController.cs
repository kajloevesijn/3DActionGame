using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Xbox360Wired_InputController : MonoBehaviour {
	private bool playerIndexSet = false;
	private PlayerIndex playerIndex;
	private GamePadState state;
	private GamePadState prevState;

    //behaviourModifiers
    [SerializeField]private float deadZoneAmount;

    //for reading
    public float leftStickAngle;
    public float rightStickAngle;
    public bool rightStickActive;
    public bool leftStickActive;
    public float leftStickX;
    public float leftStickY;

    public bool GUION;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		FindController ();
        SetState();

        if (DeadZoneCheckRight())
        {
            rightStickAngle = CalculateRotation(state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y); // calculates a angle for the right stick
        }
        else
        {


        }
        if (DeadZoneCheckLeft())
        {
            leftStickX = state.ThumbSticks.Left.X;
            leftStickY = state.ThumbSticks.Left.Y;
            leftStickAngle = CalculateRotation(state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y);   // calculates a angle for the left stick
        }
        else
        {
            leftStickX = 0f;
            leftStickY = 0f;
        }

    }
    private float CalculateRotation(float X, float Y) // calculates angle based on incoming X & Y values;
    {
        float angle = Mathf.Atan2(X, Y) * Mathf.Rad2Deg;
        //Debug.Log(angle);
        return angle;
    }

    public bool DeadZoneCheckRight()
    {
        if (state.ThumbSticks.Right.X >= deadZoneAmount || state.ThumbSticks.Right.X <= -deadZoneAmount || state.ThumbSticks.Right.Y >= deadZoneAmount || state.ThumbSticks.Right.Y <= -deadZoneAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DeadZoneCheckLeft()
    {
        if (state.ThumbSticks.Left.X >= deadZoneAmount || state.ThumbSticks.Left.X <= -deadZoneAmount || state.ThumbSticks.Left.Y >= deadZoneAmount || state.ThumbSticks.Left.Y <= -deadZoneAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void FindController(){
		// Find a PlayerIndex, for a single player game
		// Will find the first controller that is connected and use it
		if (!playerIndexSet || !prevState.IsConnected) {
			for (int i = 0; i < 4; ++i) {
				PlayerIndex testPlayerIndex = (PlayerIndex)i;
				GamePadState testState = GamePad.GetState (testPlayerIndex);
				if (testState.IsConnected) {
					Debug.Log (string.Format ("GamePad found {0}", testPlayerIndex));
					playerIndex = testPlayerIndex;
					playerIndexSet = true;
				}
			}
		}
    }
    private void SetState()
    {
        prevState = state;
        state = GamePad.GetState(playerIndex);
    }

    void OnGUI() //usefull for checking if everything works
    {
        string text = "ayy";
        if (GUION)
        {
            text = "ayylmao\n";
            text += string.Format("IsConnected {0} Packet #{1}\n", state.IsConnected, state.PacketNumber);
            text += string.Format("\tTriggers {0} {1}\n", state.Triggers.Left, state.Triggers.Right);
            text += string.Format("\tD-Pad {0} {1} {2} {3}\n", state.DPad.Up, state.DPad.Right, state.DPad.Down, state.DPad.Left);
            text += string.Format("\tButtons Start {0} Back {1} Guide {2}\n", state.Buttons.Start, state.Buttons.Back, state.Buttons.Guide);
            text += string.Format("\tButtons LeftStick {0} RightStick {1} LeftShoulder {2} RightShoulder {3}\n", state.Buttons.LeftStick, state.Buttons.RightStick, state.Buttons.LeftShoulder, state.Buttons.RightShoulder);
            text += string.Format("\tButtons A {0} B {1} X {2} Y {3}\n", state.Buttons.A, state.Buttons.B, state.Buttons.X, state.Buttons.Y);
            text += string.Format("\tSticks Left {0} {1} Right {2} {3}\n", state.ThumbSticks.Left.X, state.ThumbSticks.Left.Y, state.ThumbSticks.Right.X, state.ThumbSticks.Right.Y);
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), text);
        }
        else {
            text = "";
        }
    }
}
