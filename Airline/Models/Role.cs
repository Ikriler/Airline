using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airline.DataSetTableAdapters;
using Airline.Models;

namespace Airline.Models
{
    internal class Role
    {
        public static DataSet.RolesDataTable initRolesDataTable()
        {
            RolesTableAdapter rolesTableAdapter = new RolesTableAdapter();
            DataSet.RolesDataTable rolesDataTable = new DataSet.RolesDataTable();

            rolesTableAdapter.Fill(rolesDataTable);

            return rolesDataTable;
        }

        public static DataSet.RolesRow getRoleByUser(DataSet.UsersRow user)
        {
            DataSet.RolesDataTable rolesRows = initRolesDataTable();

            DataSet.RolesRow role = rolesRows.Where(r => r.ID.Equals(user.RoleID)).First();

            return role;
        }
    }
}
