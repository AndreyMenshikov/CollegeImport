using System.ComponentModel;

namespace WebData
{
    public enum IvrCommandType
    {
        [Description("Сброс")]
        RESET_CMD,
        [Description("Влево")]
        LEFT_CMD,
        [Description("Вправо")]
        RIGHT_CMD,
        [Description("Подтверждение")]
        DONE_CMD,
        [Description("Повторить")]
        REPLAY_CMD,
        [Description("Пропустить")]
        SKIP_CMD,
        [Description("Отмена")]
        CANCEL_CMD,
        [Description("Пустая команда")]
        NOP,
    }
}
