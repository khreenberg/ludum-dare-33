#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;
using UnityEngine.UI;

public class GameHud : MonoBehaviour {

    [SerializeField]
    private Text _scoreText, _healthText, _attackText;

    private Entity _playerEntity;

    void Awake()
    {
        _playerEntity = GameObject.FindWithTag("Player").GetComponent<Entity>();
    }

    void Update()
    {
        _scoreText.text = "Score: " + _playerEntity.Stats.ScoreValue;
        _healthText.text = string.Format("Health: {0}/{1}", _playerEntity.Stats.Health, _playerEntity.Stats.MaxHealth);
        _attackText.text = "Attack: " + _playerEntity.Stats.Attack;
    }
}
#pragma warning restore 0649
