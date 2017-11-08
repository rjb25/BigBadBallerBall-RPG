using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
//UNUSED inital testing for mulitplayer
public class Initializer : NetworkBehaviour {
    public override void OnStartLocalPlayer()
    {
        if (GameObject.Find("ConnectedPlayer(Clone)"))
        {
            print("server");
        }
 
    }

   /* public override void OnConnectedToServer() {
        print("we in");
    }
    public override void OnStartServer()
    {
        print("up");
    }
    public override void OnServerInitialized()
    {
        print("triggered");
        if (Network.isClient)
        {
            print("client");
        }
        if (Network.isServer)
        {
            print("server");
        }
    }*/
}
