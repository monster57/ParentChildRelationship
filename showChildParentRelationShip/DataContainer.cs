using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace ParentChildRelationShip
{

    public class DataContainer
    {
        private readonly QueryCreator _queryCreator;
        public DataContainer()
        {
            _queryCreator = new QueryCreator();
        }
        public Dictionary<string , Dimensions> GetAllParentsIdMappedWithDimensions()
        {
            var mappedParentIdWithDimentions = new Dictionary<string , Dimensions>();
            var query = _queryCreator.GetParentIdQuery();
            var dataTable = new DataTable();
            using (var connection = new DatabaseConnector().CreateConnection())
            {
                var command = new MySqlCommand(query, connection);
                connection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(command);
                mySqlDataAdapter.Fill(dataTable);
                
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    var parentId = dataTable.Rows[i].ItemArray[0].ToString();
                    var dimension = new Dimensions
                    {
                        Howkey = dataTable.Rows[i].ItemArray[1].ToString(),
                        Whenkey = dataTable.Rows[i].ItemArray[2].ToString(),
                        Whatkey = dataTable.Rows[i].ItemArray[3].ToString(),
                        Wherekey = dataTable.Rows[i].ItemArray[4].ToString()
                    };
                    if (!string.IsNullOrEmpty(parentId))
                        mappedParentIdWithDimentions.Add(parentId, dimension);    
                }
            }
            return mappedParentIdWithDimentions;
        } 
        public Dictionary<string, List<Fact>> GetAllChildIdMappedWithParentId(Dictionary<string, Dimensions> mappedParentIdWithDimension)
        {
            var mappedParentIdWithChildId = new Dictionary<string, List<Fact>>();
            foreach (var parentIdDataPair in mappedParentIdWithDimension)
            {
                var childIdSet = new List<Fact>();
                var query = _queryCreator.GetChildIdQuery(parentIdDataPair.Value);
                using (var connection = new DatabaseConnector().CreateConnection())
                {
                    var command = new MySqlCommand(query, connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var fact = new Fact {FactId = reader.GetValue(0).ToString()};
                        childIdSet.Add(fact);
                    }
                }
                mappedParentIdWithChildId.Add(parentIdDataPair.Key , childIdSet);
            }

            return mappedParentIdWithChildId;
        }
    }
}