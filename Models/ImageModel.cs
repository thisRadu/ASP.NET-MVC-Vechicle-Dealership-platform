using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Bazar.Models
{
    public class ImageModel
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public ImageModel()
        { }

    }
}
