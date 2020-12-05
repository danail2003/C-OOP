namespace Telephony
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Browsing(string site)
        {
            for (int i = 0; i < site.Length; i++)
            {
                if (char.IsDigit(site[i]))
                {
                    return "Invalid URL!";
                }
            }

            return $"Browsing: {site}!";
        }

        public string Calling(string number)
        {
            for (int i = 0; i < number.Length; i++)
            {
                if (char.IsLetter(number[i]))
                {
                    return "Invalid number!";
                }
            }

            if (number.Length == 7)
            {
                return $"Dialing... {number}";
            }

            return $"Calling... {number}";
        }
    }
}
