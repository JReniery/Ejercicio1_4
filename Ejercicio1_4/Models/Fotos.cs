using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicio1_4.Models
{
    public class Fotos
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string PhotoName { get; set; }
        public string Descrip { get; set; }       
        public byte[] Photo { get; set; }
        
    }
}
