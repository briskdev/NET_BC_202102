using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeApiClient
{
    public class SearchMoviesResult
    {
        public List<Movie> Search { get; set; }

        public string totalResults { get; set; }
    }
}
