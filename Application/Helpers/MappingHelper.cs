using System;

namespace Application.Helpers
{
    public static class MappingHelper
    {
        public static TDto Mapping<T, TDto>(this T item) where TDto : class
                                                         where T : class
        {
            var list = item.GetType().GetProperties();
            var inst = Activator.CreateInstance(typeof(TDto));
            foreach (var propertyInfo in list)
            {
                if (((TDto)inst).GetType().GetProperty(propertyInfo.Name) == null)
                    continue;
                var value = propertyInfo.GetValue(item, null);
                ((TDto)inst).GetType().GetProperty(propertyInfo.Name).SetValue((TDto)inst, value);
            }

            return (TDto) inst;
        }
    }
}