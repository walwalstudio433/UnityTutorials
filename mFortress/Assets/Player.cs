using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : NetworkBehaviour
{    
    public enum State
    {
        Idle, Dead, Waiting
    }

    public Angler angler;
    public Shooter shooter;
    public Mover mover;
    public TankStatusBar statusBar;
    public Image image;

    public PlayerCamera playerCamera;

    public int maxHP;

    [SyncVar(hook = "OnChangeHP")]
    public int hp;
    public string playerName;
    [SyncVar]
    public State state;

    void Start()
    {
        transform.parent = GameObject.Find("InGameCanvas").transform;
        playerCamera = GameObject.Find("PlayerCamera").GetComponent<PlayerCamera>();   
        if(isLocalPlayer)
        {
            playerCamera.ChaseTarget(transform);
        }
        hp = maxHP;  
        playerName = "player"+ netId; 
        name = playerName;
        statusBar.SetNameText(playerName);        
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
        if( state != State.Idle)
            return;

        if (InputManager.GetKeyHolding(KeyCode.DownArrow))
            OnKeyArrowDown();
        else if (InputManager.GetKeyHolding(KeyCode.UpArrow))
            OnKeyArrowUp();
        else if (InputManager.GetKeyHolding(KeyCode.Space))
            OnSpace();
        else if (InputManager.GetKeyUp(KeyCode.Space))
            OnSpaceUp();

        if (InputManager.GetKeyHolding(KeyCode.LeftArrow))
            OnKeyArrowLeft();
        else if (InputManager.GetKeyHolding(KeyCode.RightArrow))
            OnKeyArrowRight();

        if (InputManager.GetKeyUp(KeyCode.S))
        {
            S();
        }

        if (InputManager.GetKeyUp(KeyCode.H))
        {
            H();
        }

        if (Input.GetMouseButton(0) || Input.touchCount > 0)
        {
            float vertical = -Input.GetAxis("Mouse X");
            float horizontal = -Input.GetAxis("Mouse Y");
            playerCamera.MoveFeely(vertical, horizontal);
        }

        if (playerCamera.state == PlayerCamera.State.Free && InputManager.AnyArrowKeyHolding())
        {
            playerCamera.ChaseTarget(transform);
        }
    }

    public void SetState(State state)
    {
        this.state = state;
    }

    //Bullet이 SendMessage로 호출하고 있음, 메소드명 변경시 주의
    [ClientRpc]
    public void RpcTakeDamage(int dmg)
    {
        // if (!isServer)
        //     return;

        hp = System.Math.Max(hp - dmg, 0);
        if(hp == 0)
            state = State.Dead;
    }

    private void OnChangeHP(int currentHP)
    {
        statusBar.SetHPValue(currentHP / (float)maxHP);
    }

    public override void OnStartServer()
    {
        TurnManager.instance.AddPlayer(this);
    }

    public override void OnStartLocalPlayer()
    {
        image.color = Color.green;
    }

    public void OnKeyArrowLeft()
    {
        mover.MoveLeft();
        statusBar.SetStamaniaValue(mover.StaminaRatio);
    }

    public void OnKeyArrowRight()
    {
        mover.MoveRight();
        statusBar.SetStamaniaValue(mover.StaminaRatio);
    }

    public void OnKeyArrowDown()
    {
        angler.Down();
    }

    public void OnKeyArrowUp()
    {
        angler.Up();
    }

    public void OnSpace()
    {
        shooter.PowerUp();
    }

    public void OnSpaceUp()
    {
        float shotAngle = mover.direction == Mover.Direciton.Right ? angler.current : -angler.current;
        Vector3 launchV = Quaternion.Euler(0, 0, shotAngle) * mover.forward * shooter.power;
        CmdLaunch(launchV);
        shooter.Reset();
        state = State.Waiting;
    }

    [Command]
    public void CmdLaunch(Vector3 launchV)
    {
        Bullet bullet = shooter.Launch(launchV);
        NetworkServer.Spawn(bullet.gameObject);
        playerCamera.ChaseTarget(bullet.transform);
    }

    public void S()
    {
        mover.Reset();
        statusBar.SetStamaniaValue(mover.StaminaRatio);
    }

    public void H()
    {
        hp = maxHP;
    }
}
