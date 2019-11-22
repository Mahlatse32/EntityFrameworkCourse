using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DataAccessLayer;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        #region Constructor

        public MoviesController()
        {
            _dbContext = new VidlyContext();
        }

        #endregion

        #region properties

        private VidlyContext _dbContext;

        #endregion

        #region Methods

        //public 

        #endregion
    }
}
