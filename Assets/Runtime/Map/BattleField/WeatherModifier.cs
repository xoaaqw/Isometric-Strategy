using System.Text;

[System.Serializable]
public class WeatherModifier
{
    public EWeather weather;
    public int probability;

    public void Describe(StringBuilder sb)
    {
        sb.Append(probability);
        sb.Append("%");
        sb.Append("将天气改为");
        sb.Append(WeatherData.WeatherName(weather));
        sb.AppendLine();
    }
}