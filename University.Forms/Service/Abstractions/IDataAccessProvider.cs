using System.Data;

namespace UniversityApp.Forms.Service.Abstractions
{
    public interface IDataAccessProvider
    {
        DataTable ExecuteQuery(string command);

        void ExecuteNonQuery(string command);
    }
}
