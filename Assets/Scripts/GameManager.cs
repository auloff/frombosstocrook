using UnityEngine;
using FromBossToCrook.Model;
using FromBossToCrook.View;
using FromBossToCrook.Presenter;
using System;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject jobShop;
    public GameObject happinessShop;
    public GameObject healthShop;

    private JobShopPresenter _jobShopPresenter;
    private PlayerPresenter _playerPresenter;
    private ItemShopPresenter _happinesShopPresenter;
    private ItemShopPresenter _healthShopPresenter;

    void Start()
    {
        var playerView = player.GetComponent<IPlayerView>() 
            ?? throw new NullReferenceException("IPlayerView doesn't exist!");

        var playerModel = Resources.Load<SimplePlayerModel>("PlayerModel") 
            ?? throw new NullReferenceException("PlayerModel doesn't exist!");
        
        _playerPresenter = new PlayerPresenter(playerModel, playerView);

        var jobShopView = jobShop.GetComponent<IJobShopView<JobStats>>()
            ?? throw new NullReferenceException("IJobShopView doesn't exist!");

        var jobShopModel = Resources.Load<JobShopModel>("JobsListModel")
            ?? throw new NullReferenceException("JobShopModel doesn't exist!");

        _jobShopPresenter = new JobShopPresenter(jobShopModel, jobShopView);

        var happinessView = happinessShop.GetComponent<IItemsShopView<ItemStats>>()
            ?? throw new NullReferenceException("IItemsShopView for happiness doesn't exist!");

        var happinessModel = Resources.Load<ItemShopModel>("HappyItemsModel")
            ?? throw new NullReferenceException("HappinessModel doesn't exist!");

        _happinesShopPresenter = new ItemShopPresenter(happinessModel, happinessView);

        var healthView = healthShop.GetComponent<IItemsShopView<ItemStats>>()
            ?? throw new NullReferenceException("IItemsShopView for health doesn't exist!");

        var healthModel = Resources.Load<ItemShopModel>("HealthItemsModel")
            ?? throw new NullReferenceException("HealthModel doesn't exist!");

        _healthShopPresenter = new ItemShopPresenter(healthModel, healthView);

        _jobShopPresenter.GetSalary += _playerPresenter.GetMoney;
        _happinesShopPresenter.GetBuff += _playerPresenter.GetBuff;
        _healthShopPresenter.GetBuff += _playerPresenter.GetBuff;
    }
}
