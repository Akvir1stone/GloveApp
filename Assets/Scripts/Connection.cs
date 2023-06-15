using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using TMPro;
using UnityEngine.SceneManagement;





public class Connection : MonoBehaviour
{
    public static string DeviceName = "BA_100001";
	public static string ServiceUUID = "6e400001-b5a3-f393-e0a9-e50e24dcca9e";	
	public static string Characteristic = "6e400002-b5a3-f393-e0a9-e50e24dcca9e";
    public static string Characteristic2 = "6e400003-b5a3-f393-e0a9-e50e24dcca9e";
    public static string receivedMsg;
    public static bool gloveseted = false;

    public TMP_Text TextAns;
    public TMP_Text GloveStatus;
    public GameObject SetUpGlovePanel;
	public GameObject ConnectPhasePanel;
	public GameObject buttonAct;
    

    public enum States
	{
		None,
		Scan,
		Connect,
		RequestMTU,
		Subscribe,
		Unsubscribe,
		Disconnect,
		Communication,
	}

    private bool _workingFoundDevice = true;
	private bool _connected = false;
	public static float _timeout = 0f;
	public static States _state = States.None;
	private bool _foundID = false;
    public static string _BA;
	private string msg = "GA";
	private bool connectedTo = false;
	public static string receivedMess;
	public int count = 0;
    private float mtimeout;

    
	public void OnSendButton()
	{
		SceneManager.LoadSceneAsync("main");
		//SendString("GA");
	}

    
    public static void SendString(string value)
	{

		
		var data = Encoding.UTF8.GetBytes (value + "\r\n");
		BluetoothLEHardwareInterface.WriteCharacteristic (_BA, ServiceUUID, Characteristic, data, data.Length, true, (characteristicUUID) => {

			BluetoothLEHardwareInterface.Log ("Write Succeeded");            
			SetState(States.None, 0.1f);			
		});
	}
    static void SetState (States newState, float timeout)
	{
		_state = newState;
		_timeout = timeout;
	}
    void Reset ()
	{
		_workingFoundDevice = false;	// used to guard against trying to connect to a second device while still connecting to the first
		_connected = false;
		_timeout = 0f;
		_state = States.None;
		_foundID = false;
		_BA = null;
		//SetUpGlovePanel.SetActive (false);
		//ConnectPhasePanel.SetActive(true);
	}
    void StartProcess ()
	{
		

		Reset ();
		BluetoothLEHardwareInterface.Initialize (true, false, () => {
			
			SetState (States.Scan, 0.1f);
			

		}, (error) => {
			
			BluetoothLEHardwareInterface.Log ("Error: " + error);
		});
	}
    bool IsEqual(string uuid1, string uuid2)
	{
		return (uuid1.ToUpper().Equals(uuid2.ToUpper()));
	}
    
	

    void Start()
    {
        GloveStatus.text = "";
		StartProcess ();
		buttonAct.SetActive(false);
    }

    void Update()
    {		 
        if (_timeout > 0f)
		{
			_timeout -= Time.deltaTime;
			if (_timeout <= 0f)
			{
				_timeout = 0f;		

				switch (_state)
				{
				case States.None:
                    	       
					break;

				case States.Scan:
					
					GloveStatus.text = "Поиск...";

					BluetoothLEHardwareInterface.ScanForPeripheralsWithServices (null, (address, name) => {

						if (name.Contains (DeviceName))
						{
							_workingFoundDevice = true;

							BluetoothLEHardwareInterface.StopScan ();
							

							_BA = address;

							GloveStatus.text = "Перчатка найдена";

							SetState (States.Connect, 0.5f);

							_workingFoundDevice = false;
						}

					}, null, false, false);
					break;

				case States.Connect:
					
					_foundID = false;

					GloveStatus.text = "Соединение с перчаткой";
					BluetoothLEHardwareInterface.ConnectToPeripheral (_BA, null, null, (address, serviceUUID, characteristicUUID) => {

						if (IsEqual (serviceUUID, ServiceUUID))
						{							
							if (IsEqual (characteristicUUID, Characteristic))
							{
								_connected = true;
								SetState (States.RequestMTU, 2f);

								GloveStatus.text = "Соединение установлено";
							}
						}
					}, (disconnectedAddress) => {
						BluetoothLEHardwareInterface.Log ("Device disconnected: " + disconnectedAddress);
						GloveStatus.text = "Соединение не установлено";
					});
                    
                    
					break;

					case States.RequestMTU:
						GloveStatus.text = "Запрос MTU";

						BluetoothLEHardwareInterface.RequestMtu(_BA, 185, (address, newMTU) =>
						{
							GloveStatus.text = "MTU set to " + newMTU.ToString();

							SetState(States.Subscribe, 0.1f);
						});
						break;

					case States.Subscribe:
					GloveStatus.text = "Подписка на перчатку";
                    
					

					BluetoothLEHardwareInterface.SubscribeCharacteristicWithDeviceAddress (_BA, ServiceUUID, Characteristic2, null, (address, characteristicUUID, bytes) => {

						var sBytes = Encoding.ASCII.GetString(bytes);
						receivedMess = sBytes;
						TextAns.text = receivedMess;
						
					});			
					GloveStatus.text = "Готово";
					buttonAct.SetActive(true);
					break;
					
					case States.Communication:
					SendMessage("GA");
					count++;
					GloveStatus.text = "mess sended " + count.ToString() + " times";
					break;
				}
			}
		}
    }
}
