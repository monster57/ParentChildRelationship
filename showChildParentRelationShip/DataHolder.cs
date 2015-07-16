
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace showChildParentRelationShip
{

    public class DataHolder
    {
        private readonly QueryCreator _queryCreator;
        private readonly MySqlConnection _mySqlConnection;
        public DataHolder()
        {
            var databaseConnector = new DatabaseConnector();
            _queryCreator = new QueryCreator();
            _mySqlConnection = databaseConnector.CreateConnection();
        }

        public List<Dimensions> GetAllParentdata()
        {
            //new DatabaseConnector().CreateConnection() use against _mySqlConnection
            var dataTable = new DataTable();
            var dimensionses = new List<Dimensions>();
            var command = new MySqlCommand(_queryCreator.GetAllParentDataQuery(), new DatabaseConnector().CreateConnection());
            using (var connection = new DatabaseConnector().CreateConnection())
            {
                connection.Open();
                var mySqlDataAdapter = new MySqlDataAdapter(command);
                mySqlDataAdapter.Fill(dataTable);
                for (var i = 0; i < dataTable.Rows.Count; i++)
                {
                    var dimensions = new Dimensions
                    {
                        Howkey = dataTable.Rows[i].ItemArray[0].ToString(),
                        Whatkey = dataTable.Rows[i].ItemArray[1].ToString(),
                        Wherekey = dataTable.Rows[i].ItemArray[2].ToString(),
                        Whenkey = dataTable.Rows[i].ItemArray[3].ToString()
                    };
                    dimensionses.Add(dimensions);
                }
            }
            return dimensionses;
        }

        public Dictionary<string , Dimensions> GetAllParentsIdMappedWithDimensions(List<Dimensions> dimensions )
        {
            var mappedParentIdWithDimention = new Dictionary<string , Dimensions>();
            foreach (var dimension in dimensions)
            {
                if (string.IsNullOrEmpty(dimension.Whenkey)) continue;
                var query = _queryCreator.GetParentId(dimension.Whenkey, dimension.Howkey,dimension.Wherekey, dimension.Whatkey );
                var command = new MySqlCommand(query, _mySqlConnection) { CommandText = query };
                using (var connection = _mySqlConnection)
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        mappedParentIdWithDimention.Add(reader.GetValue(0).ToString() , dimension);
                    }   
                }
            }
            return mappedParentIdWithDimention;
        } 


        

        public Dictionary<string, List<Fact>> GetAllChildIdMappedWithParentId(Dictionary<string, List<Dimensions>> dictionary)
        {
            Dictionary<string , List<Fact>> mappedParentIdWithChildId = new Dictionary<string, List<Fact>>();
            foreach (var data in dictionary)
            {
                var childfacts = new List<Fact>();
                foreach (var childDimension in data.Value)
                {
                    var query = _queryCreator.GetChildIdQuery(childDimension);
                    var command = new MySqlCommand(query, _mySqlConnection) { CommandText = query };
                    using (var connection = _mySqlConnection)
                    {
                        connection.Open();
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                                var fact = new Fact {FactId = reader.GetValue(0).ToString()};
                                childfacts.Add(fact);
                        }
                    }
                }
                if (childfacts.Count != 0)
                    mappedParentIdWithChildId.Add(data.Key, childfacts);
            }

            return mappedParentIdWithChildId;
        }

        public Dictionary<string, List<Dimensions>> GetAllChildsDataMappedWithParentId(Dictionary<string, Dimensions> dictionary)
        {
            var mappedParentIdWithChildData = new Dictionary<string, List<Dimensions>>();
            foreach (var data in dictionary)
            {
                var dataTable = new DataTable();
                var query = _queryCreator.GetChildDetails(data.Value.Howkey, data.Value.Whatkey, data.Value.Wherekey, data.Value.Whenkey);
                var command = new MySqlCommand(query, _mySqlConnection) { CommandText = query };
                List<Dimensions> childDataSet = new List<Dimensions>();
                using (var connection = _mySqlConnection)
                {
                    connection.Open();
                    var mySqlDataAdapter = new MySqlDataAdapter(command);
                    mySqlDataAdapter.Fill(dataTable);
                    for (var i = 0; i < dataTable.Rows.Count; i++)
                    {
                        var dimensions = new Dimensions
                        {
                            Howkey = dataTable.Rows[i].ItemArray[0].ToString(),
                            Whatkey = dataTable.Rows[i].ItemArray[1].ToString(),
                            Wherekey = dataTable.Rows[i].ItemArray[2].ToString(),
                            Whenkey = dataTable.Rows[i].ItemArray[3].ToString()
                        };
                        childDataSet.Add(dimensions);                   
                    }
                    if (dataTable.Rows.Count != 0)
                        mappedParentIdWithChildData.Add(data.Key, childDataSet);
                }
            }  
            return mappedParentIdWithChildData;
        }
    }
}