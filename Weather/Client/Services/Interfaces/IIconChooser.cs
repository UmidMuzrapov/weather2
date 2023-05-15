using Radzen.Blazor;

namespace Weather.Client.Services
{
    public interface IIconChooser
    {

        public string GetIcon(bool isDay, int cloudcover, float rain, float snow);
    }
}
