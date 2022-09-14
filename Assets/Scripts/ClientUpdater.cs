using UnityEngine;

public class ClientUpdater : MonoBehaviour
{
    [SerializeField] private GameObject[] _clientModels;
    [SerializeField] private GameObject _currentClient;

    public void UpdateClientModel()
    {
        if (_clientModels != null && _clientModels.Length > 0)
        {
            _currentClient.SetActive(false);
            _currentClient = _clientModels[Random.Range(0, _clientModels.Length)];
            _currentClient.SetActive(true);
        }
    }
}
