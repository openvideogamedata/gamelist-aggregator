public static class EnumHelper {
    public static bool IsValidEnumValue(Type enumType, int? value)
    {
        try
        {
            if (value != null)
            {
                var validStatuses = Enum.GetValues(enumType).Cast<int>().ToList();
                return (validStatuses.Contains(value.Value));
            }
            return false;
        }
        catch
        {
            return false;
        }
    }
}