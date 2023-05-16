using Radzen.Blazor;

namespace Weather.Client.Services
{
    public interface IIconChooser
    {

        public string GetIcon(bool isDay, float cloudcover, float rain, float snow);
    }
}
