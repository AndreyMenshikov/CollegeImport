using System.ComponentModel;

namespace WebData
{
    public enum IvrItemType
    {
        [Description("Команды")]
        Commands,
        [Description("Параллели (группы классов)")]
        ClassGroups,
        [Description("Классы")]
        Classes,
        [Description("Преподаватели")]
        Teachers,
        [Description("Предметы")]
        Subjects,
        [Description("Кабинеты (аудитории)")]
        Rooms,
        [Description("Дни месяца")]
        DaysOfMonth,
        [Description("Месяцы")]
        Months,
        [Description("Отдельные части голосовых фраз")]
        SpecialParts,
        [Description("Номера уроков")]
        LessonNumbers
    }
}