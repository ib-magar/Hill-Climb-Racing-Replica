using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _followCamera;
    [SerializeField] Transform _cameraFollowObject;
    [SerializeField] Vector3 _followOffset;
    [SerializeField] bool _autoChoose;
    [SerializeField] List<CarController> _cars = new List<CarController>();
    [SerializeField] List<GameObject> _grounds=new List<GameObject>();

    [SerializeField] CarController _currentCar;
    [SerializeField] GameObject _currentGround;

    [SerializeField] Transform _startPosition;
    [SerializeField] GameObject _canvas;
    private void Start()
    {
        /*if(_autoChoose)
        {
        _currentCar = _cars[Random.Range(0, _cars.Count)];
        _currentGround = _grounds[Random.Range(0, _grounds.Count)];

        }
        SetupCar();*/
        ChooseCar(0);
        ChooseGround(0);
    }
    
    public void startGame()
    {
        _canvas.SetActive(false);
        _currentCar.GetComponent<CarController>().enabled = true;
        _followCamera.Follow = _currentCar.transform;
    }
    public void ChooseCar(int x)
    {
        _currentCar = _cars[x];
        foreach (var car in _cars)
        {
            if (car != _currentCar)
                car.gameObject.SetActive(false);
            else if (car == _currentCar)
                car.gameObject.SetActive(true);
        }
        _currentCar.transform.position = _startPosition.position;
        _currentCar.GetComponent<CarController>().enabled = false;
    }
    public void ChooseGround(int x)
    {
        _currentGround = _grounds[x];
        foreach (var ground in _grounds)
        {
            if (ground != _currentGround)
                ground.SetActive(false);
            else if (ground == _currentGround)
                ground.gameObject.SetActive(true);
        }
    }
    public void destoyCoin(GameObject coin)
    {
        coin.GetComponent<Animator>().SetTrigger("goup");
        StartCoroutine(delay(coin));
    }
    IEnumerator delay(GameObject coin)
    {
        yield return new WaitForSeconds(.4f);
        Destroy(coin.gameObject);
    }
    void SetupCar()
    {
        foreach(var car in _cars)
        {
            if (car != _currentCar)
                car.gameObject.SetActive(false);
            else if(car==_currentCar)
                car.gameObject.SetActive(true);
        }
        foreach (var ground in _grounds)
        {
            if (ground != _currentGround)
                ground.SetActive(false);
            else if(ground==_currentGround)
                ground.gameObject.SetActive(true);
            
        }


        _currentCar.transform.position = _startPosition.position;
        _followCamera.Follow = _currentCar.transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        _cameraFollowObject.position = _currentCar.transform.position + _followOffset;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; 
        Gizmos.DrawWireCube(_currentCar.transform.position + _followOffset,Vector3.one*.5f);
    }
}
