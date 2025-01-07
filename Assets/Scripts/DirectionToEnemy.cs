using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DirectionToEnemy : MonoBehaviour
{
    [SerializeField] private RectTransform indicator;
    //[SerializeField] private RectTransform arrowCenter;
    //[SerializeField] private Image arrowImage;
    [SerializeField] private Image background;
    //[SerializeField] private Text nameText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Vector2 offset;
    private EnemyMovement enemy;

    private void Start()
    {
        enemy = EnemyMovement.instance;
    }
    private void LateUpdate()
    {
        if (!enemy) return;
        if (enemy.isDead)
        {
            gameObject.SetActive(false);
        }
        OffsetScreenIndicator();
    }

    void OffsetScreenIndicator()
    {
        var indicatorPos = Camera.main.WorldToScreenPoint(enemy.gameObject.transform.position + new Vector3(0,3,0));
        if (indicatorPos.x < 0 || indicatorPos.x > Screen.width ||
            indicatorPos.y < 0 || indicatorPos.y > Screen.height)
        {
            var newPos = new Vector3(indicatorPos.x, indicatorPos.y, indicatorPos.z);
            indicatorPos.x = Mathf.Clamp(indicatorPos.x, indicator.rect.width / 2, Screen.width - indicator.rect.width / 2);
            indicatorPos.y = Mathf.Clamp(indicatorPos.y, indicator.rect.height / 2, Screen.height - indicator.rect.height / 2);
            indicatorPos.z = 0;
            indicator.position = indicatorPos;
            //nameText.gameObject.SetActive(false);
            //arrowCenter.gameObject.SetActive(true);
            Vector3 direction = (newPos - indicatorPos).normalized;
            //arrowCenter.up = direction;
        }
        else
        {
            //nameText.gameObject.SetActive(true);
            //arrowCenter.gameObject.SetActive(false);
            indicatorPos.z = 0;
            indicator.position = indicatorPos;
        }

    }
}
