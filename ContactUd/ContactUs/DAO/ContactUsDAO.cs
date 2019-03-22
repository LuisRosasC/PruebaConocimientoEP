using ContactUs.Models;
using System.Collections.Generic;

namespace ContactUs.DAO
{
    public class ContactUsDAO : DapperDAO
    {
        #region Const

        private const string QUERY_SELECT_IDENTIFICATION_TYPES = "SELECT * FROM IdentificationTypes";
        private const string QUERY_INSERT_CONTACT_US = "INSERT INTO ContactUs (CustomerFullName, IdentificationTypeId, Comments) VALUES (@CustomerFullName, @IdentificationTypeId, @Comments)";

        #endregion Const

        #region Public Methods

        public IEnumerable<IdentificationType> GetAllIdentificationTypes() =>
            base.GetList<IdentificationType>(QUERY_SELECT_IDENTIFICATION_TYPES);

        public void InsertContactUd(Models.ContactUs contactUs) =>
            base.ExecQuery(QUERY_INSERT_CONTACT_US, contactUs);

        #endregion Public Methods
    }
}