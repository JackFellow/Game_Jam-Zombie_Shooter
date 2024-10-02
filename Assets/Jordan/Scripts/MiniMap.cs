using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform playerMovemnet;
    private Transform PlayerIcon;
    float playerOffset = 1.5f;

    public GameObject Player;
    public GameObject Icon;
    public Camera Camera;

    void Start()
    {
        if (playerMovemnet != null)
        {
            playerMovemnet = Player.GetComponent<Transform>();
        }

        if (PlayerIcon != null)
        {
            PlayerIcon = Icon.GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovemnet != null && PlayerIcon != null)
        {
            PlayerIcon.transform.position = new Vector3(playerMovemnet.position.x, transform.position.y - playerOffset, playerMovemnet.position.z);

            Quaternion DesiredRoute = Quaternion.Euler(90f, playerMovemnet.eulerAngles.y, 0f);

            PlayerIcon.rotation = DesiredRoute;
        }

        if (Camera != null && playerMovemnet != null)
        {
            Vector3 newcmaeraPos = playerMovemnet.position;
            newcmaeraPos.y = Camera.transform.position.y;
            Camera.transform.position = newcmaeraPos;
        }
    }
}
