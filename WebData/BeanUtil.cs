using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebData
{
    public static class BeanUtil
    {
        public static void CopyExceptId<T>(T source, T destination)
        {
            Type myType = typeof(T);
            PropertyInfo[] propertyInfos = myType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo propertyInfo in propertyInfos
                .Where(myFieldInfo => myFieldInfo.Name.ToLower() != "id"
                   && myFieldInfo.CustomAttributes.Where(ca => ca.AttributeType.Name == "NotMappedAttribute").Count() == 0
                ))
                if (!propertyInfo.GetMethod.IsVirtual)// Особенности entity framework
                    propertyInfo.SetValue(destination, propertyInfo.GetValue(source));
        }
    }
}
