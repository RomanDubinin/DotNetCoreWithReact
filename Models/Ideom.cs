using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Ideom
    {
        public Guid Id { get; set; }

        public string EnglishText { get; set; }

        public string RussianText { get; set; }

    }
}