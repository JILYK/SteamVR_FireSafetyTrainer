using System;
using UnityEngine;
using UnityEngine.UI;

public class TaskListManager : MonoBehaviour
{
    public Text taskListText; // Объект текста на вашем CanvasTaskList

    private void Start()
    {
        Config.OnVariableChange += UpdateTaskList;
    }

    void OnEnable()
    {
        UpdateTaskList(); // Обновить при инициализации
    }

    void UpdateTaskList()
    {
        taskListText.text = string.Format(
            "{0}" + // 1. Осмотр извещателя
            "{1}" + // 2. Осмотр карты
            "{2}" + // 3. Осмотр выхода
            "{3}" + // 4. Осмотр огнетушителя
            "{4}" + // 5. Позвонить пожарным
            "{5}" + // 6. Нажать кнопку пожарной тревоги
            "{6}" + // 7. Проверить нет ли людей в здании
            "{7}" + // 8. Потушить очаг возгарания
            "{8}", // 9. Покинуть здание
            Config.detector ? "̶1̶.̶ ̶О̶с̶м̶о̶т̶р̶ ̶и̶з̶в̶е̶щ̶а̶т̶е̶л̶я̶\n" : "1. Осмотр извещателя\n",
            Config.map ? "̶2̶.̶ ̶О̶с̶м̶о̶т̶р̶ ̶к̶а̶р̶т̶ы̶\n" : "2. Осмотр карты\n",
            Config.door ? "̶3̶.̶ ̶О̶с̶м̶о̶т̶р̶ ̶в̶ы̶х̶о̶д̶а̶\n" : "3. Осмотр выхода\n",
            Config.extinguisher ? "̶4̶.̶ ̶О̶с̶м̶о̶т̶р̶ ̶о̶г̶н̶е̶т̶у̶ш̶и̶т̶е̶л̶я̶\n" : "4. Осмотр огнетушителя\n",
            Config.callFirefighters ? "̶5̶ ̶П̶о̶з̶в̶о̶н̶и̶т̶ь̶ ̶п̶о̶ж̶а̶р̶н̶ы̶м̶\n" : "5. Позвонить пожарным\n",
            Config.pressFireAlarm
                ? "̶6̶.̶ ̶Н̶а̶ж̶а̶т̶ь̶ ̶к̶н̶о̶п̶к̶у̶ ̶п̶о̶ж̶а̶р̶н̶о̶й̶ ̶т̶р̶е̶в̶о̶г̶и̶\n"
                : "6. Нажать кнопку пожарной тревоги\n",
            Config.checkForPeople
                ? "̶7̶.̶ ̶П̶р̶о̶в̶е̶р̶и̶т̶ь̶ ̶н̶е̶т̶ ̶л̶и̶ ̶л̶ю̶д̶е̶й̶ ̶в̶ ̶з̶д̶а̶н̶и̶и̶\n"
                : "7. Проверить нет ли людей в здании\n",
            Config.extinguishFire
                ? "̶8̶.̶ ̶П̶о̶т̶у̶ш̶и̶т̶ь̶ ̶о̶ч̶а̶г̶ ̶в̶о̶з̶г̶а̶р̶а̶н̶и̶я̶\n"
                : "8. Потушить очаг возгарания\n",
            Config.leaveBuilding ? "̶9̶.̶ ̶П̶о̶к̶и̶н̶у̶т̶ь̶ ̶з̶д̶а̶н̶и̶е̶\n" : "9. Покинуть здание\n"
        );
    }


    void OnDestroy()
    {
        Config.OnVariableChange -= UpdateTaskList;
    }
}