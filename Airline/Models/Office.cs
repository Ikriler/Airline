using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DataSetTableAdapters;
using Airline.Models;

namespace Airline.Models
{
    internal class Office
    {

        public static DataSet.OfficesDataTable initOfficesDataTable()
        {
            OfficesTableAdapter officesTableAdapter = new OfficesTableAdapter();
            DataSet.OfficesDataTable officesDataTable = new DataSet.OfficesDataTable();

            officesTableAdapter.Fill(officesDataTable);

            return officesDataTable;
        }

        public static DataSet.OfficesRow getOfficeByUser(DataSet.UsersRow user)
        {
            DataSet.OfficesDataTable officesRows = initOfficesDataTable();

            DataSet.OfficesRow office = officesRows.Where(o => o.ID.Equals(user.OfficeID)).First();

            return office;
        }

        public static List<String> getOfficesForCombo()
        {
            List<String> officesList = new List<String>();

            officesList = initOfficesDataTable().Select(o => o.Title).ToList();

            officesList = officesList.Prepend("All offices").ToList();

            return officesList;
        }
    }
}
