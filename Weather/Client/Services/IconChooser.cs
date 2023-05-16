namespace Weather.Client.Services
{
    public class IconChooser : IIconChooser
    {

        public string GetIcon(bool isDay, float cloudcover, float rain, float snow)
        {
            if (isDay)
            {
                if (cloudcover <10)
                {
                    return " <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#sun\" />\r\n                </svg>\r\n                <figcaption>Sunny</figcaption>\r\n                </figure>";
                }

                if (cloudcover > 10 & rain>0)
                {
                    return "  <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#sun\" x=\"-12\" y=\"-18\" />\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use id=\"drop1\" xlink:href=\"#rainDrop\" x=\"25\" y=\"65\" />\r\n                <use id=\"drop3\" xlink:href=\"#rainDrop\" x=\"45\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Patchy Rain Day</figcaption>\r\n                </figure>";
                }

                if (cloudcover>10 & snow>0)
                {
                    return "                <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#sun\" x=\"-12\" y=\"-18\" />\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use id=\"snowFlake2\" xlink:href=\"#snowFlake\" x=\"30\" y=\"65\" />\r\n                <use id=\"snowFlake4\" xlink:href=\"#snowFlake\" x=\"45\" y=\"65\" />\r\n                <use id=\"snowFlake5\" xlink:href=\"#snowFlake\" x=\"58\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Patchy Snow Day</figcaption>\r\n                </figure>";
                }
                if (rain>0)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#grayCloud\" x=\"25\" y=\"10\" class=\"reverse-small-cloud\" fill=\"url(#gradDarkGray)\" />\r\n                <use id=\"drop4\" xlink:href=\"#rainDrop\" x=\"15\" y=\"65\" />\r\n                <use id=\"drop1\" xlink:href=\"#rainDrop\" x=\"25\" y=\"65\" />\r\n                <use id=\"drop2\" xlink:href=\"#rainDrop\" x=\"37\" y=\"65\" />\r\n                <use id=\"drop3\" xlink:href=\"#rainDrop\" x=\"50\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"5\" y=\"-7\" />\r\n                </svg>\r\n                <figcaption>Rain</figcaption>\r\n                </figure>";
                }
                if (snow>0)
                {
                    return " <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use id=\"snowFlake1\" xlink:href=\"#snowFlake\" x=\"20\" y=\"55\" />\r\n                <use id=\"snowFlake2\" xlink:href=\"#snowFlake\" x=\"35\" y=\"65\" />\r\n                <use id=\"snowFlake3\" xlink:href=\"#snowFlake\" x=\"45\" y=\"60\" />\r\n                <use id=\"snowFlake4\" xlink:href=\"#snowFlake\" x=\"50\" y=\"65\" />\r\n                <use id=\"snowFlake5\" xlink:href=\"#snowFlake\" x=\"63\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"10\" y=\"-15\" />\r\n                </svg>\r\n                <figcaption>Snow</figcaption>\r\n                </figure>\r\n";
                }
                if (cloudcover <30)
                {
                    return " <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Few Clouds</figcaption>\r\n                </figure>";
                }

                if (cloudcover<50)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#sun\" x=\"-12\" y=\"-18\" />\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Partly Cloudy Day</figcaption>\r\n                </figure>";
                }

                else
                {
                    return "<figure>\r\n                        <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                            <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                            <use xlink:href=\"#grayCloud\" x=\"25\" y=\"10\" class=\"reverse-small-cloud\" fill=\"url(#gradDarkGray)\" />\r\n                            <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                        </svg>\r\n                        <figcaption>Dark Clouds</figcaption>\r\n                    </figure>";
                }
            }

            else
            {
                if (cloudcover<10)
                {
                    return " <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#moon\" x=\"-15\" />\r\n                <use xlink:href=\"#star\" x=\"42\" y=\"30\" class=\"stars animated infinite flash\" />\r\n                <use xlink:href=\"#star\" x=\"61\" y=\"32\" class=\"stars animated infinite flash delay-1s\" />\r\n                <use xlink:href=\"#star\" x=\"55\" y=\"50\" class=\"stars animated infinite flash delay-2s\" />\r\n                </svg>\r\n                <figcaption>Clear Night</figcaption>\r\n                </figure>";
                }

                if (cloudcover>10 & rain>0)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#moon\" x=\"-20\" y=\"-15\" />\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use id=\"drop1\" xlink:href=\"#rainDrop\" x=\"25\" y=\"65\" />\r\n                <use id=\"drop3\" xlink:href=\"#rainDrop\" x=\"45\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Patchy Rain Night</figcaption>\r\n                </figure>";
                }

                if (cloudcover>10 & snow>10)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#moon\" x=\"-20\" y=\"-15\" />\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use id=\"snowFlake2\" xlink:href=\"#snowFlake\" x=\"30\" y=\"65\" />\r\n                <use id=\"snowFlake4\" xlink:href=\"#snowFlake\" x=\"45\" y=\"65\" />\r\n                <use id=\"snowFlake5\" xlink:href=\"#snowFlake\" x=\"58\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Patchy Snow Night</figcaption>\r\n                </figure>";
                }

                if (rain>0)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#grayCloud\" x=\"25\" y=\"10\" class=\"reverse-small-cloud\" fill=\"url(#gradDarkGray)\" />\r\n                <use id=\"drop4\" xlink:href=\"#rainDrop\" x=\"15\" y=\"65\" />\r\n                <use id=\"drop1\" xlink:href=\"#rainDrop\" x=\"25\" y=\"65\" />\r\n                <use id=\"drop2\" xlink:href=\"#rainDrop\" x=\"37\" y=\"65\" />\r\n                <use id=\"drop3\" xlink:href=\"#rainDrop\" x=\"50\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"5\" y=\"-7\" />\r\n                </svg>\r\n                <figcaption>Rain</figcaption>\r\n                </figure>";
                }
                if (snow>0)
                {
                    return " <figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use id=\"snowFlake1\" xlink:href=\"#snowFlake\" x=\"20\" y=\"55\" />\r\n                <use id=\"snowFlake2\" xlink:href=\"#snowFlake\" x=\"35\" y=\"65\" />\r\n                <use id=\"snowFlake3\" xlink:href=\"#snowFlake\" x=\"45\" y=\"60\" />\r\n                <use id=\"snowFlake4\" xlink:href=\"#snowFlake\" x=\"50\" y=\"65\" />\r\n                <use id=\"snowFlake5\" xlink:href=\"#snowFlake\" x=\"63\" y=\"65\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"10\" y=\"-15\" />\r\n                </svg>\r\n                <figcaption>Snow</figcaption>\r\n                </figure>\r\n";
                }
                if (cloudcover<30)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Few Clouds</figcaption>\r\n                </figure>";
                }

                if (cloudcover<50)
                {
                    return "<figure>\r\n                <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                <use xlink:href=\"#moon\" x=\"-20\" y=\"-15\" />\r\n                <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                </svg>\r\n                <figcaption>Partly Cloudy Night</figcaption>\r\n                </figure>";
                }

                else
                {
                    return "<figure>\r\n                        <svg class=\"icon\" viewbox=\"0 0 100 100\">\r\n                            <use xlink:href=\"#grayCloud\" class=\"small-cloud\" fill=\"url(#gradGray)\" />\r\n                            <use xlink:href=\"#grayCloud\" x=\"25\" y=\"10\" class=\"reverse-small-cloud\" fill=\"url(#gradDarkGray)\" />\r\n                            <use xlink:href=\"#whiteCloud\" x=\"7\" />\r\n                        </svg>\r\n                        <figcaption>Dark Clouds</figcaption>\r\n                    </figure>";
                }
            }

            return " ";
        }
    }
}

