using System;
using UniversityApp.Entities;

namespace UniversityApp.Forms.Service.Validation
{
    public class UniversityValidation
    {
        private static readonly DataAccessProvider DataAccessProvider;

        static UniversityValidation()
        {
            DataAccessProvider = new DataAccessProvider();;
        }
        public static bool IsValidUniversity(University university)
        {
            if (university == null)
            {
                throw new ArgumentNullException();
            }

            if (university.UniversityName == string.Empty)
            {
                throw  new ArgumentException($"Invalid university name \'{university.UniversityName}\'");
            }

            return true;
        }

        public static bool IsPresent(University university)
        {
            var table = DataAccessProvider.ExecuteQuery($"SELECT * FROM Universities WHERE UniversityName = \'{university.UniversityName}\'");
            return table.Rows.Count <= 0;
        }
    }
}
