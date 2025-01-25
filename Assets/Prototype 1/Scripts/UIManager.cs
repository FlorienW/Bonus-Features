using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Prototype_1.Scripts
{
    public class UIManager : MonoBehaviour
    {
        
        
        public int player1CurrentVehicleIndex;
        public int player1NextVehicleIndex = 1;
        public int player2CurrentVehicleIndex;
        public int player2NextVehicleIndex = 1;
        
        public GameObject player1;
        public GameObject player2;

        public GameObject MenuUI;
        public GameObject MainCamera;
        public GameObject SecondCamera;
        
        public GameObject EndGameUICanvas;
        public TextMeshProUGUI WinnerText;
        public GameObject RestartUIReminderer;
        
        
        public static UIManager instance;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
        
            instance = this;
        }

        public void ChangePlayer1CurrentVehicle()
        {
            player1.transform.GetChild(player1CurrentVehicleIndex++).gameObject.SetActive(false);
            player1.transform.GetChild(player1NextVehicleIndex++).gameObject.SetActive(true);
            player1CurrentVehicleIndex %= 5;
            player1NextVehicleIndex %= 5;
        }
        
        public void ChangePlayer2CurrentVehicle()
        {
            player2.transform.GetChild(player2CurrentVehicleIndex++).gameObject.SetActive(false);
            player2.transform.GetChild(player2NextVehicleIndex++).gameObject.SetActive(true);
            player2CurrentVehicleIndex %= 5;
            player2NextVehicleIndex %= 5;
        }

        public void ChangePlayer1Name(string name)
        {
            GameManager.instance.ChangePlayerName(name, 1);
        }
        
        public void ChangePlayer2Name(string name)
        {
            GameManager.instance.ChangePlayerName(name, 2);
        }

        public void ExitButtonBehaviour()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
            #endif
            Application.Quit();
        }

        public void StartButtonBehaviour()
        {
            MenuUI.SetActive(false);
            MainCamera.GetComponent<Camera>().enabled = true;
            GameManager.instance.StartGame();
        }

        public void ActivateEndGameUI()
        {
            EndGameUICanvas.SetActive(true);
            StartCoroutine(ActivateRestartReminderTextAndRestartBehaviourWithDelay());
        }

        private IEnumerator ActivateRestartReminderTextAndRestartBehaviourWithDelay()
        {
            yield return new WaitForSeconds(3f);
            RestartUIReminderer.SetActive(true);
        }

        public void DeactivateEndGameUI()
        {
            EndGameUICanvas.SetActive(false);
            RestartUIReminderer.SetActive(false);
        }

        public void DeclareTheWinnerPlayer(int playerID1or2)
        {
            if (playerID1or2 == 1)
            {
                WinnerText.text = $"{GameManager.instance.Player1Name} Win!";
                return;
            }
            WinnerText.text = $"{GameManager.instance.Player2Name} Win!";
        }

        private void Update()
        {
            ChangeTheCamera();
        }

        private void ChangeTheCamera()
        {
            if (!MenuUI.activeInHierarchy && Input.GetKeyDown(KeyCode.Space))
            {
                if (SecondCamera.activeInHierarchy)
                {
                    SecondCamera.gameObject.SetActive(false);
                    MainCamera.GetComponent<Camera>().enabled = true;
                }
                else
                {
                    SecondCamera.gameObject.SetActive(true);
                    MainCamera.GetComponent<Camera>().enabled = false;
                }
            }
        }
    }
}
