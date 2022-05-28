namespace SadettinEcevitOdevHafta2_1.Extensions
{
    public static class DatetimeExtensions
    {
        public static string Ago(this DateTime date)
        {
            string retVal = string.Empty;

            if (date != null)
            {
                if (date < DateTime.Now)
                {
                    TimeSpan diff = DateTime.Now.Subtract(date);

                    int days = (int)Math.Floor(diff.TotalDays);
                    int hours = (int)Math.Floor(diff.TotalHours) - (days * 24);
                    int minutes = (int)Math.Floor(diff.TotalMinutes) - (hours * 60) - (days * 24 * 60);

                    if (days > 0)
                        retVal += days.ToString() + " gün ";
                    if (hours > 0)
                        retVal += hours.ToString() + " saat ";
                    if (minutes > 0)
                        retVal += minutes.ToString() + " dakika";

                    if (string.IsNullOrEmpty(retVal))
                    {
                        retVal += "0 dakika";
                    }

                    retVal += " önce";
                }
                else
                {
                    retVal = "İleri bir tarih girildi.";
                }
            }
            else
            {
                retVal = "Geçersiz bir tarih girildi.";
            }

            return retVal;
        }
    }
}
