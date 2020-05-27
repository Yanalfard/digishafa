using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DigiShafa.Models.Regular;

namespace DigiShafa.Utilities
{
    public class MainProvider
    {
        private static readonly string ConnectionString = Config.ConnectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private string _commandText = "";

        public MainProvider()
        {
            _connection = new SqlConnection(ConnectionString);
            _connection.Open();
        }

        private void _disconnect()
        {
            _command.Dispose();
            _connection.Close();
        }

        public enum Tables
        {
            TblIngredient,
            TblSection,
            TblPack,
            TblPackIngredientRel,
            TblDoctor,
            TblConfig
        }

        public enum PackIngredientRel
        {
            PackId,
            IngredientId
        }

        public object Add<T>(T table)
        {
            try
            {
                object tableObj = table;
                SqlCommand command;
                if (table.GetType() == typeof(TblIngredient))
                {
                    TblIngredient ingredient = (TblIngredient)tableObj;
                    if (!MethodRepo.ExistInDb("TblIngredient", "Name", ingredient.Name))
                    {
                        _commandText = $"insert into TblIngredient (Name) values (N'{ingredient.Name}' )";
                        command = new SqlCommand($"select TOP (1) * from TblIngredient where Name = '{ingredient.Name}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblIngredient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                    }
                    else return new TblIngredient(-1);
                }
                else if (table.GetType() == typeof(TblSection))
                {
                    TblSection section = (TblSection)tableObj;
                    if (!MethodRepo.ExistInDb("TblSection", "Name", section.Name))
                    {
                        _commandText = $"insert into TblSection (Name) values (N'{section.Name}' )";
                        command = new SqlCommand($"select TOP (1) * from TblSection where Name = '{section.Name}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblSection(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                    }
                    else return new TblSection(-1);
                }
                else if (table.GetType() == typeof(TblPack))
                {
                    TblPack pack = (TblPack)tableObj;
                    if (!MethodRepo.ExistInDb("TblPack", "Name", pack.Name))
                    {
                        _commandText = $"insert into TblPack (Name , Description , SectionId) values (N'{pack.Name}' , N'{pack.Description}' , N'{pack.SectionId}' )";
                        command = new SqlCommand($"select TOP (1) * from TblPack where Name = '{pack.Name}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblPack(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0);
                    }
                    else return new TblPack(-1);
                }
                else if (table.GetType() == typeof(TblPackIngredientRel))
                {
                    TblPackIngredientRel packIngredientRel = (TblPackIngredientRel)tableObj;

                    _commandText = $"insert into TblPackIngredientRel (PackId , IngredientId) values (N'{packIngredientRel.PackId}' , N'{packIngredientRel.IngredientId}' )";
                    command = new SqlCommand($"select TOP (1) * from TblPackIngredientRel where id = '{packIngredientRel.id}' ORDER BY id DESC", _connection);
                    _command = new SqlCommand(_commandText, _connection);
                    _command.ExecuteNonQuery();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new TblPackIngredientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PackId"].ToString() != "" ? Convert.ToInt32(reader["PackId"]) : 0, reader["IngredientId"].ToString() != "" ? Convert.ToInt32(reader["IngredientId"]) : 0);
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    if (!MethodRepo.ExistInDb("TblDoctor", "Image", doctor.Image))
                    {
                        _commandText = $"insert into TblDoctor (Name , Image , Description , SectionId) values (N'{doctor.Name}' , N'{doctor.Image}' , N'{doctor.Description}' , N'{doctor.SectionId}' )";
                        command = new SqlCommand($"select TOP (1) * from TblDoctor where Image = '{doctor.Image}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Image"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0);
                    }
                    else return new TblDoctor(-1);
                }
                else if (table.GetType() == typeof(TblConfig))
                {
                    TblConfig config = (TblConfig)tableObj;
                    if (!MethodRepo.ExistInDb("TblConfig", "TellNo", config.TellNo))
                    {
                        _commandText = $"insert into TblConfig (TellNo) values (N'{config.TellNo}' )";
                        command = new SqlCommand($"select TOP (1) * from TblConfig where TellNo = '{config.TellNo}' ORDER BY id DESC", _connection);
                        _command = new SqlCommand(_commandText, _connection);
                        _command.ExecuteNonQuery();
                        SqlDataReader reader = command.ExecuteReader();
                        reader.Read();
                        return new TblConfig(reader["TellNo"].ToString());
                    }
                    else return new TblConfig();
                }
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Update<T>(T table, int logId)
        {
            try
            {
                object tableObj = table;
                if (table.GetType() == typeof(TblIngredient))
                {
                    TblIngredient ingredient = (TblIngredient)tableObj;
                    _commandText = $"update TblIngredient set Name = N'{ingredient.Name}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblSection))
                {
                    TblSection section = (TblSection)tableObj;
                    _commandText = $"update TblSection set Name = N'{section.Name}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblPack))
                {
                    TblPack pack = (TblPack)tableObj;
                    _commandText = $"update TblPack set Name = N'{pack.Name}' , Description = N'{pack.Description}' , SectionId = N'{pack.SectionId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblPackIngredientRel))
                {
                    TblPackIngredientRel packIngredientRel = (TblPackIngredientRel)tableObj;
                    _commandText = $"update TblPackIngredientRel set PackId = N'{packIngredientRel.PackId}' , IngredientId = N'{packIngredientRel.IngredientId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblDoctor))
                {
                    TblDoctor doctor = (TblDoctor)tableObj;
                    _commandText = $"update TblDoctor set Name = N'{doctor.Name}' , Image = N'{doctor.Image}' , Description = N'{doctor.Description}' , SectionId = N'{doctor.SectionId}' where id = N'{logId}'";
                }
                else if (table.GetType() == typeof(TblConfig))
                {
                    TblConfig config = (TblConfig)tableObj;
                    _commandText = $"update TblConfig set TellNo = N'{config.TellNo}' where id = N'{logId}'";
                }
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public bool Delete(Tables tableType, int id)
        {
            try
            {
                _commandText = $"delete from {tableType.ToString()} where id = N'{id}'";
                _command = new SqlCommand(_commandText, _connection);
                _command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                _disconnect();
            }
        }

        public IEnumerable SelectAll(Tables tableType)
        {
            try
            {
                _commandText = $"select * from {tableType.ToString()}";
                _command = new SqlCommand(_commandText, _connection);
                SqlDataReader reader = _command.ExecuteReader();
                switch (tableType)
                {
                    case Tables.TblIngredient:
                        List<TblIngredient> ingredients = new List<TblIngredient>();
                        while (reader.Read())
                            ingredients.Add(new TblIngredient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString()));
                        return ingredients;
                    case Tables.TblSection:
                        List<TblSection> sections = new List<TblSection>();
                        while (reader.Read())
                            sections.Add(new TblSection(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString()));
                        return sections;
                    case Tables.TblPack:
                        List<TblPack> packs = new List<TblPack>();
                        while (reader.Read())
                            packs.Add(new TblPack(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0));
                        return packs;
                    case Tables.TblPackIngredientRel:
                        List<TblPackIngredientRel> packIngredientRels = new List<TblPackIngredientRel>();
                        while (reader.Read())
                            packIngredientRels.Add(new TblPackIngredientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PackId"].ToString() != "" ? Convert.ToInt32(reader["PackId"]) : 0, reader["IngredientId"].ToString() != "" ? Convert.ToInt32(reader["IngredientId"]) : 0));
                        return packIngredientRels;
                    case Tables.TblDoctor:
                        List<TblDoctor> doctors = new List<TblDoctor>();
                        while (reader.Read())
                            doctors.Add(new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Image"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0));
                        return doctors;
                    case Tables.TblConfig:
                        List<TblConfig> configs = new List<TblConfig>();
                        while (reader.Read())
                            configs.Add(new TblConfig(reader["TellNo"].ToString()));
                        return configs;
                    default:
                        return new List<bool>();
                }
            }
            catch
            {
                return new List<bool>();
            }
            finally
            {
                _disconnect();
            }
        }

        public object SelectById(Tables table, int id)
        {
            try
            {
                _command = new SqlCommand($"select * from {table.ToString()} where id = '{id}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                if (table == Tables.TblIngredient)
                    return new TblIngredient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                else if (table == Tables.TblSection)
                    return new TblSection(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
                else if (table == Tables.TblPack)
                    return new TblPack(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0);
                else if (table == Tables.TblPackIngredientRel)
                    return new TblPackIngredientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PackId"].ToString() != "" ? Convert.ToInt32(reader["PackId"]) : 0, reader["IngredientId"].ToString() != "" ? Convert.ToInt32(reader["IngredientId"]) : 0);
                else if (table == Tables.TblDoctor)
                    return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Image"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0);
                else if (table == Tables.TblConfig)
                    return new TblConfig(reader["TellNo"].ToString());

                return null;
            }
            catch
            {
                return null;
            }
            finally
            {
                _disconnect();
            }
        }

        #region TblIngredient

        public TblIngredient SelectIngredientByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblIngredient where Name = N'{name}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblIngredient(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString());
            }
            catch
            {
                return new TblIngredient(-1);
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblSection

        public List<TblSection> SelectSectionByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblSection where Name like N'%{name}%'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                List<TblSection> res = new List<TblSection>();
                while (reader.Read())
                    res.Add(new TblSection(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString()));
                return res;
            }
            catch
            {
                return new List<TblSection>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPack

        public List<TblPack> SelectPackByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblPack where Name like N'%{name}%'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                List<TblPack> res = new List<TblPack>();
                while (reader.Read())
                    res.Add(new TblPack(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0));
                return res;
            }
            catch
            {
                return new List<TblPack>();
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblPack> SelectPackBySectionId(int sectionId)
        {
            try
            {
                List<TblPack> ret = new List<TblPack>();
                _command = new SqlCommand($"select* from TblPack where SectionId = N'{sectionId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPack(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblPack>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblPackIngredientRel

        public List<TblPackIngredientRel> SelectPackIngredientRel(int entry, PackIngredientRel entryType)
        {
            try
            {
                List<TblPackIngredientRel> ret = new List<TblPackIngredientRel>();
                if (entryType == PackIngredientRel.PackId)
                    _command = new SqlCommand($"select* from TblPackIngredientRel where PackId = N'{entry}'", _connection);
                else if (entryType == PackIngredientRel.IngredientId)
                    _command = new SqlCommand($"select* from TblPackIngredientRel where IngredientId = N'{entry}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblPackIngredientRel(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["PackId"].ToString() != "" ? Convert.ToInt32(reader["PackId"]) : 0, reader["IngredientId"].ToString() != "" ? Convert.ToInt32(reader["IngredientId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblPackIngredientRel>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblDoctor

        public List<TblDoctor> SelectDoctorByName(string name)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where Name like N'%{name}%'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                List<TblDoctor> res = new List<TblDoctor>();
                while (reader.Read())
                    res.Add(new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Image"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0));
                return res;
            }
            catch
            {
                return new List<TblDoctor>();
            }
            finally
            {
                _disconnect();
            }
        }
        public TblDoctor SelectDoctorByImage(string image)
        {
            try
            {
                _command = new SqlCommand($"select* from TblDoctor where Image = N'{image}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Image"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0);
            }
            catch
            {
                return new TblDoctor(-1);
            }
            finally
            {
                _disconnect();
            }
        }
        public List<TblDoctor> SelectDoctorBySectionId(int sectionId)
        {
            try
            {
                List<TblDoctor> ret = new List<TblDoctor>();
                _command = new SqlCommand($"select* from TblDoctor where SectionId = N'{sectionId}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                while (reader.Read())
                    ret.Add(new TblDoctor(reader["id"].ToString() != "" ? Convert.ToInt32(reader["id"]) : 0, reader["Name"].ToString(), reader["Image"].ToString(), reader["Description"].ToString(), reader["SectionId"].ToString() != "" ? Convert.ToInt32(reader["SectionId"]) : 0));
                return ret;
            }
            catch
            {
                return new List<TblDoctor>();
            }
            finally
            {
                _disconnect();
            }
        }

        #endregion

        #region TblConfig

        public TblConfig SelectConfigByTellNo(string tellNo)
        {
            try
            {
                _command = new SqlCommand($"select* from TblConfig where TellNo = N'{tellNo}'", _connection);
                SqlDataReader reader = _command.ExecuteReader();
                reader.Read();
                return new TblConfig(reader["TellNo"].ToString());
            }
            catch
            {
                return new TblConfig();
            }
            finally
            {
                _disconnect();
            }
        }
        #endregion

    }
}
