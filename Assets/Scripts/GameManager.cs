using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FromBossToCrook.Model;
using FromBossToCrook.View;
using FromBossToCrook.Tools.Calendar;
using FromBossToCrook.Presenter;
using System;

public class GameManager : MonoBehaviour
{
    [Min(0)]
    public int playerAge = 18;
    [Min(0)]
    public int playerMaxAge = 83;

    public GameObject player;
    public JobShopPresenter jobShopPresenter;

    private PlayerPresenter _playerPresenter;

    void Start()
    {
        IPlayerView playerView = null;

        if (!player.TryGetComponent<IPlayerView>(out playerView)) throw new NullReferenceException("IPlayerView doesn't exist!");

        _playerPresenter = new PlayerPresenter(new SimplePlayerModel(playerAge, playerMaxAge), playerView);
        _playerPresenter.GetMoney(2000);
        _playerPresenter.ChangeHappiness(100);
        _playerPresenter.ChangeHealth(100);

        jobShopPresenter.GetSalary += (salary) => _playerPresenter.GetMoney(salary);
    }
}
