using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebData
{
    public enum MediaType
    {
        [Description("Видео")]
        Video,
        [Description("Изображения")]
        Image,
        [Description("Аудио")]
        Audio,
        [Description("Документы")]
        Document
    }
}
