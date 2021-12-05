using System.Globalization;

namespace Recape.Attributes;

public class DataFuturaAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        DateTime data;
        var isDataFutura = DateTime.TryParseExact(
            Convert.ToString(value),
            "yyyy-MM-dd",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out data);

        return (isDataFutura && data > DateTime.Now);
    }
}
