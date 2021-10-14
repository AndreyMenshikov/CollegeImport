using System.ComponentModel;

namespace WebData
{
    public enum IvrSpecialPartTypes
    {
        [Description("Урок отсутствует")]
        SP_ABSENT,
        [Description("Расписание для")]
        SP_TIMETABLE_FOR,
        [Description("Вы находитесь в главном меню")]
        SP_YOU_ARE_IN_MAIN_MENU,
        [Description("Сегодня")]
        SP_TODAY,
        [Description("Следующий день")]
        NEXT_DAY,
        [Description("Предыдущий день")]
        PREVIOUSE_DAY
    }
}
