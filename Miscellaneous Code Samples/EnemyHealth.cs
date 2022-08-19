using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class EnemyHealth : MoreMountains.TopDownEngine.Health
{
    [SerializeField]
    UIManager uiManager;
    public MoreMountains.TopDownEngine.Loot loot;
    public MMFeedbacks destroyMMFeedbacks;

    protected override void Start()
    {
        base.Start();
    }

    public override void Kill()
    {
        base.Kill();
        uiManager.UpdateRemainingEnemyCount();
        destroyMMFeedbacks?.PlayFeedbacks(this.transform.position);
    }

    public override void Initialization()
    {
        base.Initialization();

        if (uiManager == null)
        {
            uiManager = FindObjectOfType<UIManager>();
        }

        if (loot == null)
        {
            loot = gameObject.GetComponent<MoreMountains.TopDownEngine.Loot>();
        }

        destroyMMFeedbacks?.Initialization(this.gameObject);
    }

    void DestroyFeedback()
    {
        destroyMMFeedbacks?.PlayFeedbacks(this.transform.position);
    }
}
