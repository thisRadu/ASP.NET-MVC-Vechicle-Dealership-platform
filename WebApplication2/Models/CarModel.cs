using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bazar.Models
{
    public class CarModel
    {
        private int id;
        private string marca;
        private string modelul;
        private int anul;
        private int volumul;
        private int puterea;
        private string combustibilul;
        private string caroseria;
        private string fotografia;
        private string descriere;
        private int pretul;
        private string contact;
        
        public int Id
        {
            get { return id; }
            set
            {
                
                id = value;
            }
        }
        public string Marca
        {
            get { return marca; }
            set
            {
                marca = value;
            }
        }
        public string Modelul
        {
            get { return modelul; }
            set
            {
                modelul = value;
            }
        }
        public int Anul
        {
            get { return anul; }
            set
            {
                anul = value;
            }
        }
        public int Volumul
        {
            get { return volumul; }
            set
            {
                volumul = value;
            }
        }
        public int Puterea
        {
            get { return puterea; }
            set
            {
                puterea = value;
            }
        }
        public string Combustibilul
        {
            get { return combustibilul; }
            set
            {
                combustibilul = value;
            }
        }
        public string Caroseria
        {
            get { return caroseria; }
            set
            {
                caroseria = value;
            }
        }
        public string Fotografia
        {
            get { return fotografia; }
            set
            {
                fotografia = value;
            }
        }
        public string Descriere
        {
            get { return descriere; }
            set
            {
                descriere = value;
            }
        }
        public int Pretul
        {
            get { return pretul; }
            set
            {
                pretul = value;
            }
        }
        public string Contact
        {
            get { return contact; }
            set
            {
                contact = value;
            }
        }
        public CarModel()
        {
            /*
                        Marca = "NA";
                        Modelul = "NA";
                        Anul = 0;
                        Volumul = 0;
                        Puterea = 0;
                        Combustibilul = "NA";
                        Caroseria = "NA";
                        Fotografia = "NA";
                        Descriere = "NA";
                        Pretul = 0;
                        Contact = "NA";
            */
        }

        public CarModel(SqlDataReader reader)
        {
            Id = Convert.ToInt32(reader["id"]);
            Marca = reader["marca"].ToString();
            Modelul = reader["modelul"].ToString();
            Anul = Convert.ToInt32(reader["anul"]);
            Volumul = Convert.ToInt32(reader["volumul"]);
            Puterea = Convert.ToInt32(reader["puterea"]);
            Combustibilul = reader["combustibilul"].ToString();
            Caroseria = reader["caroseria"].ToString();
            Fotografia = reader["fotografia"].ToString();
            Descriere = reader["descriere"].ToString();
            Pretul = Convert.ToInt32(reader["pretul"]);
            Contact = reader["contact"].ToString();
        }
    }
}
