using MedicalManagementSystem.Domain.Entities;
using System.Globalization;

namespace MedicalManagementSystem.Domain.Commands
{
    public class LocalizableEntities : BaseEntity
    {
        public string GetLocalized(string NameEn, string NameAr)
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return NameAr;
            return NameEn;
        }
    }
}
