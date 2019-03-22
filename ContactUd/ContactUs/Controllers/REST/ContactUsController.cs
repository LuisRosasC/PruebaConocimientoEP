using ContactUs.DAO;
using System.Web.Http;

namespace ContactUs.Controllers.REST
{
    [RoutePrefix("api/contactUs")]
    public class ContactUsController : ApiController
    {
        #region Properties

        private readonly ContactUsDAO _dao;

        #endregion Properties
        
        #region Constructor

        public ContactUsController() =>
            _dao = new ContactUsDAO();

        #endregion Constructor

        #region Public Methods

        [HttpGet]
        [Route("identificationType")]
        public IHttpActionResult GetAllIdentificationTypes()
        {
            var identificationTypes = _dao.GetAllIdentificationTypes();
            return Ok(identificationTypes);
        }

        [HttpPost]
        [Route("contactUs")]
        public IHttpActionResult UpdateContactUs([FromBody]Models.ContactUs content)
        {
            if (content == null)
                return BadRequest("The parameters are missing.");
            _dao.InsertContactUd(content);
            return Ok();
        }
        
        #endregion Public Methods
    }
}