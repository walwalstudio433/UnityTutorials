using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class TurnManager : NetworkBehaviour
{
	public static TurnManager instance;

    public delegate void OnChangePlayerDele(int playerIndex);

    [SyncEvent]
    public event OnChangePlayerDele EventOnChangePlayer;

    public List<Player> players;
    public Player current;

	public int index;

	private void Awake() {
		instance = this;        
	}

    private void OnGUI() {
        if(!isServer)
            return;

         if (GUI.Button(new Rect(10, 150, 100, 30), "Move Next")){
             CmdMoveNext();
         }

         
            
    }

	void Start()
    {
		
    }

	public void AddPlayer(Player player)
	{
		players.Add(player);
	}

    public static void MoveNext(float seconds)
    {
        instance.Invoke("CmdMoveNext", seconds);
    }

    [Command]
    private void CmdMoveNext()
    {
        if (++instance.index == instance.players.Count)
            instance.index = 0;
        instance.current = instance.players[instance.index];
        instance.current.SetState(Player.State.Idle);
    }

}
